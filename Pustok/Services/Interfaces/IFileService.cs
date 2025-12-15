namespace Pustok.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file, string folder);
        bool DeleteFile(string filePath);
        bool FileExists(string filePath);
        string GetFileUrl(string filePath);
    }
}
