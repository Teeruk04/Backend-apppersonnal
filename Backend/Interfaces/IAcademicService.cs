using Backend.DTOS.Academics;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IAcademicService
    {
        Task<IEnumerable<Academicposition>> FindAll();
        Task<object> FindByAcademicId(int id);
        Task<object> FindByUserId(int userid);
        Task<object> Update(AcademicUpdate data, int id);
        Task Create(Academicposition academicposition);
        Task Delete(object academicposition);
        Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);
    }
}
