using Microsoft.AspNetCore.Mvc;
using RoleRightApp.Services.Models;

namespace RoleRightApp.Services.Abstractions;

public interface IStorageService
{
    Task<string> UploadFileAsync(S3ObjectUpload obj);
}
