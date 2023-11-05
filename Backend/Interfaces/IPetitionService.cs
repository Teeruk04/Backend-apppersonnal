using Backend.Models;

namespace Backend.Interfaces
{
    public interface IPetitionService
    {
        Task<IEnumerable<Petition>> FindAll(string? search);
        Task<object> FindByPetitionId(int id);
        Task Create(Petition petition);
        Task Delete(object petition);
        Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);

        Task<object> ConfirmPetiton(int id);
        Task<object> CancelPetition(int id);
        Task<object> AcceptPetition(int id);
    }
}
