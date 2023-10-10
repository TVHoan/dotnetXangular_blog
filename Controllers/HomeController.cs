using DotnetAngular.Data;
using DotnetAngular.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetAngular.Controllers;
[ApiController]
public class HomeController: ControllerBase
{
    private ApplicationDbContext _context;
    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
/*    private Slide[] slide = new[]
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
    };*/
    [HttpGet("api/bannerslide")]
    public SlideDto[] GetSlides()
    {
       var data =  _context.Slides.ToList();
        return data.Select(x=> new SlideDto
        {   
            Urlimage = x.Urlimage,
           Active  =   x.Active
        }).ToArray();
    }
}