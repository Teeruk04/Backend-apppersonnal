using Backend.DTOS.Users;
using Backend.Interfaces;
using Backend.Models;
using Backend.Settings;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext databaseContext;
        private readonly JwtSetting jwtSetting;
        private readonly IUploadFileService uploadFileService;

        public UserService(DatabaseContext databaseContext , JwtSetting jwtSetting, IUploadFileService uploadFileService)
        {
            this.databaseContext = databaseContext;
            this.jwtSetting = jwtSetting;
            this.uploadFileService = uploadFileService;
        }
        private bool VerifyPassword(string saltAndHashFromDB, string Password)
        {
            var parts = saltAndHashFromDB.Split('.', 2);
            if (parts.Length != 2) return false;

            var salt = Convert.FromBase64String(parts[0]);
            var passwordHash = parts[1];


            var hashed = HashPassword(Password, salt);

            var ere = hashed == passwordHash;

            return hashed == passwordHash;
        }

        private string HashPassword(string password, byte[] salt)
        {

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
        public async Task Delete(User user)
        {
            databaseContext.Users.Remove(user);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> FindAll(string? search)
        {
            var users = await databaseContext.Users
                .Include(x => x.Title)
                .Include(x=>x.StatusU)
                .Include(x=>x.Sex).ToListAsync();
            if (!String.IsNullOrEmpty(search))
            {
                users =  users.Where(x =>
                x.User_name.Contains(search) || 
                x.User_lastname.Contains(search) ||
                x.StatusU.StatusU_name.Contains(search) 
                ).ToList();
            }
            
            return users;
        }

        public async Task<object> FindById(int id)
        {
           return await databaseContext.Users.Include(x => x.Title).Include(x=>x.StatusU).Include(x=>x.Sex).SingleOrDefaultAsync(x => x.Id.Equals(id));

            
            
        }

        public string GenerateToken(User user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,user.User_name),
                new Claim("Title",user.Title.Title_name),
                new Claim("userId",user.Id.ToString()),
                new Claim("additonal","TestSomething"),
                new Claim("todo day","10/10/99")
            };
            return BuildToken(claims);
        }


        private string BuildToken(Claim[] claims)
        {
            var expires = DateTime.Now.AddDays(Convert.ToDouble(jwtSetting.Expire));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //สร้าง Token
            var token = new JwtSecurityToken(
                issuer: jwtSetting.Issuer,
                audience: jwtSetting.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<object?> GetByToken(string? useToken)
        {
            if (useToken is null) return new { statusCode = 400, message = "no token" };

            var token = new JwtSecurityTokenHandler().ReadToken(useToken) as JwtSecurityToken;

            var id = token!.Claims.First(claim => claim.Type == "userId").Value;
            var result = await databaseContext.Users.Include(a => a.Title).Include(a=>a.StatusU).Include(a=>a.Sex).FirstOrDefaultAsync(a => a.Id.Equals(int.Parse(id)));
            if (result is null) return new { statusCode = 400, message = "no user" };
            return new { statusCode = 200, message = "success", data = UserResponse.FromUser(result) };
        }

        public async Task<User> Login(string Email, string Password)
        {
            var user = await databaseContext.Users.Include(x => x.Title).SingleOrDefaultAsync(p => p.Email == Email);
            //var tt = VerifyPassword(user.Password, Password);
            if(user !=null && VerifyPassword(user.Password, Password))
            {
                return user;
            }

            return null;
        }

        public async Task Register(User user)
        {
            var result = await databaseContext.Users.SingleOrDefaultAsync(x => x.Email == user.Email);
            if (result != null) throw new Exception("Existing account");

            user.Password = CreateHashPassword(user.Password);
            await databaseContext.Users.AddAsync(user);
            await databaseContext.SaveChangesAsync();
        }

         private string CreateHashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            var hashed = HashPassword(password, salt);

            //ไม่ใชโชว์ข้อมูล
            var hpw = $"{Convert.ToBase64String(salt)}.{hashed}";
            return hpw;
        }

        public async Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles)
        {

            var errorMessage = string.Empty;
            var imageName = string.Empty;

            if (uploadFileService.IsUpload(formFiles))
            {
                errorMessage = uploadFileService.Validation(formFiles);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    imageName = (await uploadFileService.UploadImages(formFiles))[0];
                }
            }

            return (errorMessage, imageName);
        }

        

        public async Task Update(User user)
        {
            databaseContext.Update(user);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<object> Update(UserUpdate data,int userid)
        {
            var result = await databaseContext.Users.FirstOrDefaultAsync(a => a.Id.Equals(userid));
            if(result is null) return new { statusCode = 400, message="ไม่พบข้อมูล" };


            #region Check and UploadImage
            (string errorMessage, string imageName) = await UploadImage(data.FormFile!);
            if (!string.IsNullOrEmpty(errorMessage)) return new { statusCode = 400, message = errorMessage }; 
            if (!string.IsNullOrEmpty(imageName))
            {
                await uploadFileService.DeleteImages(result.Field!);
                result.Field = imageName;
            }
            #endregion

            
            result.User_name = data.User_name;
            result.User_lastname = data.User_lastname;
            result.User_cardnumber = data.User_cardnumber;
            result.User_birthdate = data.User_birthdate;
            result.User_placeofbirth = data.User_placeofbirth;
            result.User_race = data.User_race;  
            result.User_nationality = data.User_nationality;
            result.User_religion = data.User_religion;   
            result.id_title = data.id_title;
            result.id_statusU = data.id_statusU;
            result.id_sex = data.id_sex;

            await databaseContext.SaveChangesAsync();

            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };
        }
    }   
}
