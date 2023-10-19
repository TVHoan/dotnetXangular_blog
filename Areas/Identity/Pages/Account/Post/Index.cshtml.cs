using DotnetAngular.Contract;
using DotnetAngular.Controllers;
using DotnetAngular.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using static DotnetAngular.Areas.Identity.Pages.Account.Role.UserModel;

namespace DotnetAngular.Areas.Identity.Pages.Account.Post
{
    [Authorize(Roles = "admin")]

    public class IndexModel : PageModel
    {
        public IndexModel(IBlogController   blog)
        {
            _blog = blog;
        }
        private readonly IBlogController _blog;
        public PostDto[] posts { get; set; }
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
            /*            HttpClient client = new HttpClient();
             *            
            */
            /*            var data =  await _client.GetAsync($"{baseuri}/api/aboutcontent?skip={Skip}&take={Take}");
                       var total =  await _client.GetAsync($"{baseuri}/api/totalpost");*/
            var data = await _blog.GetListAsync(new InputDto { Skip = Skip, Take = Take });
            var total = await _blog.CountTotalPost();
            if (data.Length>0 )
            {
                posts = data;
                Total = total;
            }
        }
        public async Task OnPostAsync() => await OnGetAsync();

    }
}
