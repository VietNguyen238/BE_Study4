using Microsoft.AspNetCore.Http;

namespace be_study4.Interfaces
{
    public interface IUploadImageRepository
    {
        Task<string> Upload(IFormFile file);
    }
}