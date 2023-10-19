using DotnetAngular.Contract;
using DotnetAngular.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DotnetAngular.Areas.Identity.Pages.Account.Slide
{
    [Authorize(Roles = "admin")]

    public class AddModel : PageModel
    {
        private readonly ISlideController _slide;
        private readonly IBlogController _blog;

        [BindProperty]
        public SlideViewModel Slide { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }
        [BindProperty]
        public string? urlimage { get; set; } = "";
        public AddModel(ISlideController slide, IBlogController blog)
        {
            _slide = slide;
            _blog = blog;
        }

        public async Task OnGetAsync()
        {
            if (Id != null)
            {
                var data = await _slide.GetAsync(int.Parse(Id.ToString()));
                Slide = new SlideViewModel
                {
                    Active = data.Active,
                };
                urlimage = data.Urlimage;
            }
            else
            {
                Slide = new SlideViewModel();

            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Id != null)
            {
                if (Slide.Image != null)
                {
                    urlimage = await _blog.UploadFile(Slide.Image);
                }


                await _slide.UpdateAsync(int.Parse(Id.ToString()), new SlideDto
                {
                    Urlimage = urlimage,
                    Active = Slide.Active
                });
                return Page();
            }
            else
            {   if(urlimage != null)
                {
                    urlimage = await _blog.UploadFile(Slide.Image);

                }
                else
                {
                    urlimage = "";
                }
                await _slide.CreateAsync(new SlideDto
                {
                    Urlimage = urlimage,
                    Active = Slide.Active
   
                });
                return RedirectToPage("./Index");

            }
        }
    }
    public class SlideViewModel
    {
        [Display(Name = "Ảnh")]
        public IFormFile? Image { get; set; }
        [Required]
        [Display(Name = "Hiển thị")]
        public bool Active { get; set; }
    }
}