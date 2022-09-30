namespace RoleRightApp.Services.Helpers;

public static class S3Helper
{
    public static string GetS3ObjectKey(string? prefix, IFormFile file)
    {
        return string.IsNullOrEmpty(prefix) ? file.FileName : $"{prefix?.TrimEnd('/')}/{file.FileName}";
    }
}
