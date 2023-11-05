using Backend.DTOS.Academics;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class AcademicService : IAcademicService
    {
        private readonly DatabaseContext databaseContext;
        private readonly IUploadFileService uploadFileService;

        public AcademicService(DatabaseContext databaseContext, IUploadFileService uploadFileService)
        {
            this.databaseContext = databaseContext;
            this.uploadFileService = uploadFileService;
        }

        public async Task Create(Academicposition academicposition)
        {
            await databaseContext.Academicpositions.AddAsync(academicposition);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object academicposition)
        {
            databaseContext.Academicpositions.Remove((Academicposition)academicposition);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Academicposition>> FindAll()
        {
            var academics = await databaseContext.Academicpositions.ToListAsync();
            return academics;
        }

        public async Task<object> FindByAcademicId(int id)
        {
            return await databaseContext.Academicpositions.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<object> FindByUserId(int userid)
        {
          
            return await databaseContext.Users.Include(x=>x.Academicpositions).FirstOrDefaultAsync(x=>x.Id.Equals(userid));
        }

        public async Task<object> Update(AcademicUpdate data, int id)
        {
            var result = await databaseContext.Academicpositions.FirstOrDefaultAsync(a => a.Id.Equals(id));
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

            result.academic_position =data.academic_position;
            result.academic_branchcode = data.academic_branchcode;
            result.academic_branchname = data.academic_branchname;
            result.academic_startdate = data.academic_startdate;
            result.academic_refer = data.academic_refer;
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
    }
}
