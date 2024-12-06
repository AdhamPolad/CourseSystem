using CourseSystem.Dtos.File;

namespace CourseSystem.Services.Interfaces
{
    public interface IFileService
    {
        Task Upload(IFormFile formFile, int userId);
        Task<FileResponceDto> Download(int userId);

    }
}
