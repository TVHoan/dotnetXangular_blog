using DotnetAngular.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAngular.Controllers;
[ApiController]
public class HomeController: ControllerBase
{
    private Slide[] slide = new[]
    {
        new Slide
        {
            Urlimage = "./assets/images/img1.jpg",
            Active = true
        },
        new Slide
        {
            Urlimage = "./assets/images/img2.jpg",
            Active = false
        }
    };
    [HttpGet("api/bannerslide")]
    public Slide[] GetSlides()
    {
        return slide;
    }
}