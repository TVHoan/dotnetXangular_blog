using DotnetAngular.Dto;
using DotnetAngular.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAngular.Contract
{
    public interface ISlideController
    {
        Task<SlideDto[]> GetListAsync([FromQuery] InputDto input);
        Task CreateAsync([FromBody] SlideDto input);
        Task UpdateAsync([FromQuery] int id, [FromBody] SlideDto input);
        Task DeleteAsync([FromQuery] int id);
        Task<Slide> GetAsync([FromQuery] int id);
    }
}
