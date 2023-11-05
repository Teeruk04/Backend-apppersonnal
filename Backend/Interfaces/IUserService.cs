using Backend.DTOS.Users;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> FindAll(string? search);
        Task<object> FindById(int id);
        Task Register(User user);
        Task<User> Login (string Email, string Password);
        Task<object> Update(UserUpdate data, int id);
        string GenerateToken(User user);
        Task<object?> GetByToken(string? useToken);
        Task Delete(User user);
        Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);

    }
}
