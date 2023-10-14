using DotnetAngular.Data;
using DotnetAngular.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetAngular.Controllers;
[ApiController]
public class BlogController: ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BlogController(ApplicationDbContext context)
    {
        _context = context;
    }

    private PostDto[] content = new[]
    {
        new PostDto
        {
            Id = "1",
            Title = "The biggest and most awesome camera of year",
            Createdat = "MAY 14 2019 5 READ",
            Content =
                "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
            Imageurl = "./assets/images/blog1.png"
        },
        new PostDto
        {
            Id = "2",
            Title = "What 3 years of android taught me the hard way",
            Createdat = "MAY 19 2019 5 READ",
            Content =
                "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable."         ,
            Imageurl = "./assets/images/blog2.png"
        },
        new PostDto
        {
            Id = "3",
            Title = " 2 The biggest and most awesome camera of year",
            Createdat = "MAY 14 2019 5 READ",
            Content =
                "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
            Imageurl = "./assets/images/blog1.png"
        },
        new PostDto
        {
            Id = "4",
            Title = " 2 What 3 years of android taught me the hard way",
            Createdat = "MAY 19 2019 5 READ",
            Content =
                "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable."         ,
            Imageurl = "./assets/images/blog2.png"
        }
    };
    private CommentDto[] comments = new[]
    {
        new CommentDto
        {
            Id = "1",
            PostId = "1",
            Name = "Veniam - Veniam@gmail.com",
            Content =
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.",
            Createdat = DateTime.Today
        },
        new CommentDto
        {
            Id = "2",
            PostId = "1",
            Name = "Jack - Jack@gmail.com",
            Content =
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.",
            Createdat = DateTime.Today
        }
    };
    [HttpGet]
    [Route("api/aboutcontent")]
    public  PostDto[] GetContentAbout([FromQuery]CommentInputDto input)
    {
        var data =  _context.Posts.Where(X=>X.PostTypeId==null).Skip(input.Skip?? 0).Take(input.Take ?? 2).ToArray();
        return data.Select(x => new PostDto
        {
            Id = x.Id.ToString(),
            Title = x.Title,
            Content = x.Content,
            Createdat = x.Createdat.ToShortDateString(),
            Imageurl = x.Imageurl

        }).ToArray();
    }

   
    [HttpGet]
    [Route("api/blogdetailcontent")]
    public PostDto GetDetail([FromQuery] string id)
    {
       return content.FirstOrDefault(x => x.Id == id);
    }
    [HttpGet]
    [Route("api/comment")]
    public CommentDto[] GetListComment([FromQuery] string Postid)
    {
        return comments.Where(x=>x.PostId==Postid).ToArray() ;
    }
    [HttpPost]
    [Route("api/post/create")]
    public async Task<int> CreatePost([FromBody]PostInputDto input)
    {
        return await _context.Database.ExecuteSqlRawAsync("EXEC  CreatePost @Title @Createdat @Content @Imageurl @PostTypeId",
             input.Title, DateTime.Now, input.Content, input.Imageurl, input.PostTypeId);
    }

}