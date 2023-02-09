using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace WebScrapingService;

public class CloudinaryMediaService : IMediaService
{
    private Cloudinary _cloudinary;

    public CloudinaryMediaService(Account account)
    {
        _cloudinary = new Cloudinary(account);
    }

    public async Task<string> Upload(string url)
    {
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(url),
            UseFilename = false,
            UniqueFilename = true,
            Overwrite = true,
        };
        var uploadResult = await _cloudinary.UploadAsync(uploadParams);
        return uploadResult.Url.ToString();
    }
}