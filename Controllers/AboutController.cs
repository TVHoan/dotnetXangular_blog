using DotnetAngular.Data;
using DotnetAngular.Dto;
using DotnetAngular.Dto.PostType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetAngular.Controllers
{
    [ApiController]
    public class AboutController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AboutController(ApplicationDbContext context)
        {
            _context = context;
        }

/*        string contentpage = "<div class=\"section layout_padding dark_bg\">\r\n  <div class=\"container\">\r\n\r\n    <div class=\"row\">\r\n      <div class=\"col-md-6\">\r\n        <img src=\"images/marketing_img.png\" alt=\"#\" />\r\n      </div>\r\n      <div class=\"col-md-6\">\r\n        <div class=\"full blog_cont\">\r\n          <h3 class=\"white_font\">Where can I get some</h3>\r\n          <h5 class=\"grey_font\">March 19 2019 5 READ</h5>\r\n          <p class=\"white_font\">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined g to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator..</p>\r\n        </div>\r\n      </div>\r\n    </div>\r\n\r\n  </div>\r\n</div>\r\n<div class=\"section layout_padding\">\r\n  <div class=\"container\">\r\n\r\n    <div class=\"row\">\r\n      <div class=\"col-md-6\">\r\n        <div class=\"full blog_cont\">\r\n          <h3>Where can I get some</h3>\r\n          <h5>March 19 2019 5 READ</h5>\r\n          <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined g to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator..</p>\r\n        </div>\r\n      </div>\r\n      <div class=\"col-md-6\">\r\n        <img src=\"assets/images/marketing_img.png\" alt=\"#\" />\r\n      </div>\r\n\r\n    </div>\r\n  </div>\r\n</div>";
*/      [HttpGet]
        [Route("api/aboutpage")]
        public PageContentDto GetContent()
        {
            var aboutcontent = _context.Posts.Where(x => x.PostTypeId == PostTypeConst.About).FirstOrDefault();
            PageContentDto content = new PageContentDto();
            content.Content = aboutcontent.Content;
            return content;
        }
    }
}
