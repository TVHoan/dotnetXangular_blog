using DotnetAngular.Contract;
using DotnetAngular.Controllers;
using DotnetAngular.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static DotnetAngular.Areas.Identity.Pages.Account.Role.UserModel;

namespace DotnetAngular.Areas.Identity.Pages.Account.Slide
{
    public class IndexModel : PageModel
    {
        public IndexModel(IBlogController   blog, ISlideController slide)
        {
            _blog = blog;
            _slide = slide;
        }
        private readonly IBlogController _blog;
        private readonly ISlideController _slide;
        public SlideDto[] slides { get; set; }
        public string StatusMessage { get; set; }
        public int? Skip { get; set; } = 0;
        public int? Take { get; set; } = 3;
        public int Pagenumber { get; set; } = 1;
        public int Total { get; set; }
        public async Task OnGetAsync()
        {
            var baseuri = Request.Scheme + "://" + Request.Host.Value;
            Pagenumber = Request.Query["p"].Any() ?  int.Parse(Request.Query["p"].ToString()) : 1 ;
            Take = Request.Query["s"].Any() ? int.Parse(Request.Query["s"].ToString()) : Take;
            Skip = (Pagenumber-1)* Take;

            var data = await _slide.GetListAsync(new InputDto { Skip = Skip, Take = Take });
            if (data.Length>0 )
            {
                slides = data;
                Total = 1;
            }
        }
    }
}
