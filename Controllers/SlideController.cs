using DotnetAngular.Contract;
using DotnetAngular.Data;
using DotnetAngular.Dto;
using DotnetAngular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetAngular.Controllers
{
    [ApiController]
    public class SlideController : ControllerBase, ISlideController
    {
        private readonly ApplicationDbContext _context;

        public SlideController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("api/slide")]
        public async Task<SlideDto[]> GetListAsync([FromQuery] InputDto input)
        {
            var data = await _context.Slides.Skip(input.Skip ?? 0).Take(input.Take ?? 3).ToArrayAsync();
            return data.Select(x =>
            new SlideDto
            {   Id = x.Id,
                Urlimage = x.Urlimage,
                Active = x.Active,

            }).ToArray();
        }
        [HttpGet]
        [Route("api/blogdetailcontent")]
        public async Task<Slide> GetAsync([FromQuery] int id)
        {
            return await _context.Slides.FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpPost]
        [Route("api/slide/create")]
        public async Task CreateAsync([FromBody] SlideDto input)
        {
             await _context.AddAsync(new Slide { Urlimage=input.Urlimage,Active=input.Active});
             await _context.SaveChangesAsync();
        }
        [HttpPost]
        [Route("api/slide/update")]
        public async Task UpdateAsync([FromQuery] int id, [FromBody] SlideDto input)
        {
            Slide slide = await _context.Slides.FindAsync(id);
            if (slide != null)
            {
                await _context.Slides.Where(x => x.Id == id).ExecuteUpdateAsync(setter => setter
                .SetProperty(a => a.Urlimage, input.Urlimage)
                .SetProperty(x => x.Active, input.Active)); 
            }

        }
        [HttpPost]
        [Route("api/post/delete")]
        public async Task DeleteAsync([FromQuery] int id)
        {
            Slide slide = await _context.Slides.FindAsync(id);
            if (slide != null)
            {
                await _context.Slides.Where(x => x.Id == id).ExecuteDeleteAsync(); ;
            }
        }
    }
}
