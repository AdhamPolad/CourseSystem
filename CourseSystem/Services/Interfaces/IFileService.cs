using CourseSystem.Dtos.File;
using Microsoft.AspNetCore.Mvc;

namespace CourseSystem.Services.Interfaces
{
    public interface IFileService
    {
        Task Upload(IFormFile formFile, int userId);
        Task<FileResponceDto> Download(int userId);

    }
}
