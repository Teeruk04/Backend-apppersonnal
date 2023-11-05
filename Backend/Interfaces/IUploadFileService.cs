namespace Backend.Interfaces
{
    public interface IUploadFileService
    {
         bool IsUpload(IFormFileCollection formFiles);

        string Validation(IFormFileCollection formFiles);

        Task<List<string>> UploadImages(IFormFileCollection formFiles); 
        Task DeleteImages(string fileName);
    }
}
