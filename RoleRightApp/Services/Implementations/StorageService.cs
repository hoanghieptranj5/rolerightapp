using Amazon.S3;
using Amazon.S3.Model;
using RoleRightApp.Services.Abstractions;
using RoleRightApp.Services.Helpers;
using RoleRightApp.Services.Models;

namespace RoleRightApp.Services.Implementations;

public class StorageService : IStorageService
{
    private readonly IAmazonS3 _s3Client;

    public StorageService(IAmazonS3 s3Client)
    {
        _s3Client = s3Client;
    }

    public async Task<string> UploadFileAsync(S3ObjectUpload s3RequestUpload)
    {
        var path = S3Helper.GetS3ObjectKey(s3RequestUpload.Prefix, s3RequestUpload.File);
        var bucketExists = false;
        var errorMessage = string.Empty;

        try
        {
            bucketExists = await _s3Client.DoesS3BucketExistAsync(s3RequestUpload.BucketName);
            errorMessage = $"Bucket {s3RequestUpload.BucketName} does not exist.";
        }
        catch(Exception ex)
        {
            errorMessage = $"Fail to connect to S3";
        }

        if (bucketExists)
        {
            var request = new PutObjectRequest()
            {
                BucketName = s3RequestUpload.BucketName,
                Key = path,
                InputStream = s3RequestUpload.File.OpenReadStream()
            };
            request.Metadata.Add("Content-Type", s3RequestUpload.File.ContentType);
            await _s3Client.PutObjectAsync(request);
            return $"{s3RequestUpload.File.FileName} upload succesfully.";
        }
        return errorMessage;
    }
}
