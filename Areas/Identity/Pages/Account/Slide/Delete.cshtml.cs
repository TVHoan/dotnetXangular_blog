using DotnetAngular.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace DotnetAngular.Areas.Identity.Pages.Account.Slide
{
    [Authorize(Roles = "admin")]

    public class DeleteModel : PageModel
    {
        private readonly ISlideController _slide;

        [BindProperty(SupportsGet =true)]
        public int? Id { get; set; }
        public DeleteModel(ISlideController slide)
        {
            _slide = slide;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Id != null) {
                await _slide.DeleteAsync(int.Parse(Id.ToString()));
                return Redirect("./Index");
            }
            return Page();
        }
    }
}
