using DotnetAngular.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAngular.Contract
{
    public interface IBlogController
    {
        Task<PostDto[]> GetContentAbout([FromQuery] InputDto input);
        Task<int> CountTotalPost();
        Task<int> CreatePost([FromBody] PostInputDto input);
        Task<string> UploadFile(IFormFile file);
        Task<PostDto> GetDetail([FromQuery] int id);
        Task Update([FromQuery] int id, [FromBody] PostInputDto input);
        Task Delete([FromQuery] int id);
        Task<PostDto[]> GetListAsync([FromQuery] InputDto input);
    }
}
