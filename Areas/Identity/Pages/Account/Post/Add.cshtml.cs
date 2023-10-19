using DotnetAngular.Contract;
using DotnetAngular.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DotnetAngular.Areas.Identity.Pages.Account.Post
{
    [Authorize(Roles = "admin")]

    public class AddModel : PageModel
    {
        private readonly IBlogController _blog;

        [BindProperty]
        public PostViewModel Post { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }
        [BindProperty]
        public string? urlimage { get; set; } = "";
        public AddModel(IBlogController blog)
        {
            _blog = blog;
        }

        public async Task OnGetAsync()
        {
            if (Id != null)
            {
                var data = await _blog.GetDetail(int.Parse(Id.ToString()));
                Post = new PostViewModel
                {
                    Title = data.Title,
                    Content = data.Content,
                };
                urlimage = data.Imageurl;
            }
            else
            {
                Post = new PostViewModel();

            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Id != null)
            {
                if (Post.Imageurl != null)
                {
                    urlimage = await _blog.UploadFile(Post.Imageurl);
                }
 

                await _blog.Update(int.Parse(Id.ToString()), new PostInputDto
                {
                    Title = Post.Title,
                    Content = Post.Content,
                    Imageurl = urlimage,
                });
                return Page();
            }
            else
            {   if(Post.Imageurl != null)
                {
                    urlimage = await _blog.UploadFile(Post.Imageurl);

                }
                else
                {
                    urlimage = "";
                }
                await _blog.CreatePost(new PostInputDto
                {
                    Title = Post.Title,
                    Content = Post.Content,
                    Imageurl = urlimage,
                });
                return RedirectToPage("./Index");

            }
        }
    }
    public class PostViewModel
    {
        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Ảnh bìa")]
        public IFormFile? Imageurl { get; set; }
    }
}