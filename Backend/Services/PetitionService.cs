using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class PetitionService : IPetitionService
    {
        private readonly DatabaseContext databaseContext;
        private readonly IUploadFileService uploadFileService;

        public PetitionService(DatabaseContext databaseContext, IUploadFileService uploadFileService)
        {
            this.databaseContext = databaseContext;
            this.uploadFileService = uploadFileService;
        }

        public async Task<object> AcceptPetition(int id)
        {
            var result = await databaseContext.Petitions.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (result == null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };


            result.peti_staus = "ตรวจสอบรายละเอียด";
            databaseContext.Petitions.Update(result);
            await databaseContext.SaveChangesAsync();
            return new { statusCode = 200, message = "บันทึกข้อมูลสำเร็จ" };
        }

        public async Task<object> CancelPetition(int id)
        {
            var result = await databaseContext.Petitions.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (result == null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };


            result.peti_staus = "รอเจ้าหน้าที่รับเรื่อง";
            databaseContext.Petitions.Update(result);
            await databaseContext.SaveChangesAsync();
            return new { statusCode = 200, message = "บันทึกข้อมูลสำเร็จ" };
        }

        public async Task<object> ConfirmPetiton(int id)
        {
            var result = await databaseContext.Petitions.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (result == null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };


            result.peti_staus = "วินิจฉัยเสร็จสิ้น";
            databaseContext.Petitions.Update(result);
            await databaseContext.SaveChangesAsync();
            return new { statusCode = 200, message = "บันทึกข้อมูลสำเร็จ" };
        }

        public async Task Create(Petition petition)
        {
            await databaseContext.Petitions.AddAsync(petition);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object petition)
        {
            databaseContext.Petitions.Remove((Petition)petition);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Petition>> FindAll(string? search)
        {
            var petitions = await databaseContext.Petitions.Include(x=>x.Author).ToListAsync();
            if (!String.IsNullOrEmpty(search))
            {
                petitions = petitions.Where(x=>
                x.Author.User_name.Contains(search) ||
                x.Createdate.Year.ToString().Contains(search) ||
                x.peti_staus.Contains(search) 
                ).ToList();
            }
            return petitions;
        }

        public async Task<object> FindByPetitionId(int id)
        {
            return await databaseContext.Petitions.Include(x => x.Author).SingleOrDefaultAsync(x => x.Id.Equals(id));
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
    }
}
