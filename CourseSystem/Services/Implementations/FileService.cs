using CourseSystem.Data;
using CourseSystem.Dtos.File;
using CourseSystem.Entities.AppDbContextEntity;
using CourseSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseSystem.Services.Implementations
{
    public class FileService : IFileService
    {
        private CourseSystemDbContext _courseSystemDbContext { get; set; }
        private IConfiguration _configuration { get; set; }

        public FileService(CourseSystemDbContext courseSystemDbContext, IConfiguration configuration)
        {
            _courseSystemDbContext = courseSystemDbContext;
            _configuration = configuration;
        }

        public async Task Upload(IFormFile formFile, int userId)
        {
            FileDetails fileDetails = new()
            {
                FileName = $"{formFile.FileName.Split('.')[0]}_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}",
                Extension = $".{formFile.FileName.Split('.')[1]}",
                UserId = userId
            };
            
            string fileName = FileOperation(fileDetails);
            using FileStream fileStream = new FileStream(fileName, FileMode.Create);
            await formFile.CopyToAsync(fileStream);

            await DbOperation(fileDetails);

        }

        private string FileOperation(FileDetails fileDetails)
        {
            string folderPath = _configuration["configs:filePath"];
            string fullPath = Path.GetFullPath(Path.Combine(folderPath, "UploadFiles"));

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            string fileName = Path.Combine(fullPath, $"{fileDetails.FileName}{fileDetails.Extension}");
            return fileName;
        }

        private async Task DbOperation(FileDetails fileDetails)
        {
            await _courseSystemDbContext.FileDetails.AddAsync(fileDetails);
            await _courseSystemDbContext.SaveChangesAsync();
        }

        public async Task<FileResponceDto> Download(int userId)
        {
            User? user = await _courseSystemDbContext.Users.Where(x=>x.Id == userId)
                                                                .Include(x=>x.FileDetails)
                                                                .FirstOrDefaultAsync();

            FileDetails? fileDetails = user.FileDetails?.FirstOrDefault();

            if (fileDetails == null) return null;

            string fileName = FileOperation(fileDetails);

            byte[] fileBytes = await File.ReadAllBytesAsync(fileName);

            return new FileResponceDto()
            {
                Data = fileBytes,
                FileName = $"{fileDetails.FileName}{fileDetails.Extension}"
            };


        }



    }
}
