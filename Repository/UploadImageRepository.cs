using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using be_study4.Interfaces;

namespace be_study4.Repository
{
    public class UploadImageRepository : IUploadImageRepository
    {
        private readonly IConfiguration _config;

        public UploadImageRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> Upload(IFormFile file)
        {
            List<string> vaidExtentions = new List<string>() { ".jpg", ".png", ".gif", ".webp" };
            string extention = Path.GetExtension(file.FileName);
            if (!vaidExtentions.Contains(extention))
            {
                return $"Extention is not valid({string.Join(',', vaidExtentions)})";
            }

            long size = file.Length;
            if (size > (5 * 1024 * 1024))
            {
                return "Maximum size can be 5mb";
            }

            Account account = new Account(
                _config["CLOUDINARY:CloudName"],
                _config["CLOUDINARY:ApiKey"],
                _config["CLOUDINARY:ApiSecret"]);

            Cloudinary cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                PublicId = Guid.NewGuid().ToString(),
                Transformation = new Transformation().Width(1024).Height(768).Crop("scale")
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            return uploadResult.SecureUrl.ToString();
        }
    }
}