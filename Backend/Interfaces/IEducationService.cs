using Backend.DTOS.Educations;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IEducationService
    {
        Task<IEnumerable<Education>> FindAll();
        Task<object> FindByEducationId(int id);
        Task<object> Update(EducationUpdate data, int id);
        Task Create (Education education);  
        Task Delete (object education);
        Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);

    }
}
