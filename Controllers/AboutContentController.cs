using System.Reflection.Metadata.Ecma335;
using DotnetAngular.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAngular.Controllers;
[ApiController]

public class AboutContentController: ControllerBase
{
    private ContentDto[] content = new[]
    {
        new ContentDto
        {
            Title = "The biggest and most awesome camera of year",
            Createdat = "MAY 14 2019 5 READ",
            Content =
                "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
            Imageurl = "./assets/images/blog1.png"
        },
        new ContentDto
        {
            Title = "What 3 years of android taught me the hard way",
            Createdat = "MAY 19 2019 5 READ",
            Content =
                "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable."         ,   
            Imageurl = "./assets/images/blog2.png"
        }
    };
    [HttpGet]
    [Route("api/aboutcontent")]
    public  ContentDto[] GetContentAbout()
    {
         return content;
    }
}