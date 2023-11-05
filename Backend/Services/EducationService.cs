using Backend.DTOS.Educations;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class EducationService : IEducationService
    {
        private readonly DatabaseContext databaseContext;
        private readonly IUploadFileService uploadFileService;

        public EducationService(DatabaseContext databaseContext, IUploadFileService uploadFileService)
        {
            this.databaseContext = databaseContext;
            this.uploadFileService = uploadFileService;
        }
        public async Task Create(Education education)
        {
           await databaseContext.Educations.AddAsync(education);
           await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object education)
        {
           databaseContext.Educations.Remove((Education) education);
            await databaseContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Education>> FindAll()
        {
           var educations = await databaseContext.Educations.Include(x=>x.Level).ToListAsync();
            return educations;
        }

        public async Task<object> FindByEducationId(int id)
        {
           return await databaseContext.Educations.Include(x => x.Level).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public Task<object> FindByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<object> Update(EducationUpdate data, int id)
        {
            var result = await databaseContext.Educations.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };

            #region Check and UploadImage
            (string errorMessage, string imageName) = await UploadImage(data.FormFile!);
            if (!string.IsNullOrEmpty(errorMessage)) return new { statusCode = 400, message = errorMessage };
            if (!string.IsNullOrEmpty(imageName))
            {
                await uploadFileService.DeleteImages(result.File!);
                result.File = imageName;
            }
            #endregion

            result.Educa_startdate = data.Educa_startdate;
            result.Educa_enddate = data.Educa_enddate;
            result.Educa_placename = data.Educa_placename;
            result.Educa_location = data.Educa_location;
            result.Educa_course = data.Educa_course;
            result.Educa_results = data.Educa_results;
            result.id_level = data.id_level;

            await databaseContext.SaveChangesAsync();

            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };
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

        //public async Task<object> FindByUserId(int id)
        //{
        //   var result = await databaseContext.Educations.Where(a=>a.id_user.Equals(id)).ToListAsync();
        //    return new
        //    {
        //        statusCode = 200,
        //        message = "success",
        //        data = result
        //    };
        //}
    }
}
