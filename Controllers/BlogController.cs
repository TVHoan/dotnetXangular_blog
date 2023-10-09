using DotnetAngular.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAngular.Controllers;
[ApiController]
public class BlogController: ControllerBase
{
    private ContentDto[] content = new[]
    {
        new ContentDto
        {   
            Id = "1",
            Title = "The biggest and most awesome camera of year",
            Createdat = "MAY 14 2019 5 READ",
            Content =
                "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
            Imageurl = "./assets/images/blog1.png"
        },
        new ContentDto
        {
            Id = "2",
            Title = "What 3 years of android taught me the hard way",
            Createdat = "MAY 19 2019 5 READ",
            Content =
                "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable."         ,   
            Imageurl = "./assets/images/blog2.png"
        },
        new ContentDto
        {   
            Id = "3",
            Title = "The biggest and most awesome camera of year",
            Createdat = "MAY 14 2019 5 READ",
            Content =
                "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
            Imageurl = "./assets/images/blog1.png"
        },
        new ContentDto
        {
            Id = "4",
            Title = "What 3 years of android taught me the hard way",
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
    public  ContentDto[] GetContentAbout([FromQuery]CommentInputDto input)
    {
        return content.Skip(input.Skip?? 0).Take(input.Take ?? 2).ToArray();
    }
   
    [HttpGet]
    [Route("api/blogdetailcontent")]
    public ContentDto GetDetail([FromQuery] string id)
    {
       return content.FirstOrDefault(x => x.Id == id);
    }
    [HttpGet]
    [Route("api/comment")]
    public CommentDto[] GetListComment([FromQuery] string Postid)
    {
        return comments.Where(x=>x.PostId==Postid).ToArray() ;
    }
}