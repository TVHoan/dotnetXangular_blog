using DotnetAngular.Contract;
using DotnetAngular.Data;
using DotnetAngular.Dto;
using DotnetAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
namespace DotnetAngular.Controllers;
[ApiController]
public class BlogController: ControllerBase,IBlogController
{
    private readonly ApplicationDbContext _context;

    public BlogController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    [Route("api/aboutcontent")]
    public  async Task<PostDto[]> GetContentAbout([FromQuery]InputDto input)
    {
        var data = await _context.Posts.Where(X=>X.PostTypeId==null).Skip(input.Skip?? 0).Take(input.Take ?? 2).ToArrayAsync();
        return data.Select(x => 
        new PostDto
        {
            Id = x.Id.ToString(),
            Title = x.Title,
            Content = x.Content.Length > 100 ? x.Content.Substring(0, 100 )+"..." : x.Content,
            Createdat = x.Createdat.ToShortDateString(),
            Imageurl = x.Imageurl

        }).ToArray();
    }
    [HttpGet]
    [Route("api/post")]
    public async Task<PostDto[]> GetListAsync([FromQuery] InputDto input)
    {

        var data = await _context.Posts.Skip(input.Skip ?? 0).Take(input.Take ?? 2).ToArrayAsync();
        return data.Select(x =>
        new PostDto
        {
            Id = x.Id.ToString(),
            Title = x.Title,
            Content = x.Content.Length > 100 ? x.Content.Substring(0, 100) + "..." : x.Content,
            Createdat = x.Createdat.ToShortDateString(),
            Imageurl = x.Imageurl

        }).ToArray();
    }
    [HttpGet]
    [Route("api/totalpost")]
    public async Task<int> CountTotalPost()
    {
        return await _context.Posts.CountAsync();
    }

    [HttpGet]
    [Route("api/blogdetailcontent")]
    public async Task<PostDto> GetDetail([FromQuery] int id)
    {
       var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
        return new PostDto
        {
            Id = post.Id.ToString(),
            Title = post.Title,
            Content = post.Content,
            Imageurl = post.Imageurl

        };
    }
    [HttpGet]
    [Route("api/comment")]
    public CommentDto[] GetListComment([FromQuery] int Postid)
    {
        var commmets =  _context.Comments.Where(x=>x.PostId == Postid).ToArray() ;
        return commmets.Select(x => new CommentDto
        {
            Id=x.Id.ToString(),
            PostId = x.PostId.ToString(),
            Name = x.Name,
            Content = x.Content,
            Createdat = x.Createdat
        }).ToArray();
    }
    [HttpPost]
    [Route("api/post/create")]
    public async Task<int> CreatePost([FromBody]PostInputDto input)
    {
        return await _context.Database
            .ExecuteSqlInterpolatedAsync($"EXEC CreatePost {input.Title}, {DateTime.Now},{input.Content},{input.Imageurl},{input.PostTypeId}");
    }
    [HttpPost]
    [Route("api/post/update")]
    public async Task Update([FromQuery]int id, [FromBody] PostInputDto input)
    {
        Post post = await _context.Posts.FindAsync(id);
        if (post != null)
        {
            await _context.Posts.Where(x=>x.Id==id).ExecuteUpdateAsync(setter => setter
            .SetProperty(a => a.Title, input.Title)
            .SetProperty(x=>x.Content, input.Content)
            .SetProperty(x => x.Imageurl ,input.Imageurl)); ;
        }

    }
    [HttpPost]
    [Route("api/post/delete")]
    public async Task Delete([FromQuery] int id)
    {
        Post post = await _context.Posts.FindAsync(id);
        if (post != null)
        {
            await _context.Posts.Where(x => x.Id == id).ExecuteDeleteAsync(); ;
        }
    }

    [HttpPost]
    [Route("api/post/uploadfile")]
    public async Task<string?> UploadFile(IFormFile file)
    {
        if (file != null & file.Length > 0)
        {
            var fileName = Path.GetFileName(file.FileName.Replace(file.FileName, DateTime.Now.Ticks.ToString() + file.FileName));
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return "uploads/images/"+fileName;
        }
        return string.Empty;
    }

    

}