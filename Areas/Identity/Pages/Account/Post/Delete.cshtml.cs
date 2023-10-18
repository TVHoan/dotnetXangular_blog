using DotnetAngular.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetAngular.Areas.Identity.Pages.Account.Post
{
    public class DeleteModel : PageModel
    {
        private readonly IBlogController _blog;

        [BindProperty(SupportsGet =true)]
        public int? Id { get; set; }
        public DeleteModel(IBlogController blog)
        {
            _blog = blog;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Id != null) {
                await _blog.Delete(int.Parse(Id.ToString()));
                return Redirect("./Index");
            }
            return Page();
        }
    }
}
