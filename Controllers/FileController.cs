using DotnetAngular.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAngular.Controllers
{
    [ApiController]
    public class FileController: ControllerBase {
        [HttpPost]
        [Route("api/uploadfile")]
        public async Task<FileUploadDto> UploadFile(IFormFile upload)
        {
            if (upload != null & upload.Length > 0)
            {
                var fileName = Path.GetFileName(upload.FileName.Replace(upload.FileName, DateTime.Now.Ticks.ToString()+upload.FileName));
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images",fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await upload.CopyToAsync(stream);
                }
                return new FileUploadDto { Default = "https://localhost:44498/uploads/images/" + fileName };
            }
            return new FileUploadDto { Default = string.Empty };
        }
    }
}
