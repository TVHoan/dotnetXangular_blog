using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotnetAngular.Areas.Admin.Pages.Role;

    public class IndexRoleModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexRoleModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public List<IdentityRole> roles {set; get;}

        [TempData] // Sử dụng Session lưu thông báo
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            roles  =  await _roleManager.Roles.ToListAsync();
            return Page();
        }
    }
