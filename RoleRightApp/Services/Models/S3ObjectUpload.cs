namespace RoleRightApp.Services.Models;

public class S3ObjectUpload
{
    public IFormFile File { get; set; } = null!;    
    public string BucketName { get; set; } = null!;
    public string? Prefix { get; set; } = null!;

    public S3ObjectUpload(IFormFile file, string bucketName, string? prefix)
    {
        File = file;
        BucketName = bucketName;
        Prefix = prefix;
    }
}
