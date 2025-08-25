using FirstWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;

namespace FirstWebApp.Controllers
{
    [Authorize(Roles = clsRoles.adminRole)]
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> _user;
        private readonly RoleManager<IdentityRole> _roles;

        public RolesController(UserManager<IdentityUser> user, RoleManager<IdentityRole> roles)
        {
            _user = user;
            _roles = roles;
        }
        public async Task<IActionResult> Index()
        {
            List<IdentityUser> users = await _user.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> addRoles(string? userId)
        {
            IdentityUser user = await _user.FindByIdAsync(userId);
            IList<string> userRoles = await _user.GetRolesAsync(user);
            List<IdentityRole> allRole = await _roles.Roles.ToListAsync();
            if (allRole != null)
            {
                var roleList = allRole.Select(r => new roleViewModel
                {
                    roleId = r.Id,
                    roleName = r.Name,
                    useRole = userRoles.Any(x => x == r.Name)

                });
                ViewBag.userId = user.Id;
                ViewBag.userName = user.UserName;
                return View(roleList);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addRoles(string userId, string jsonRoles)
        {
            var user = await _user.FindByIdAsync(userId);

            List<roleViewModel> myRoles =
                JsonConvert.DeserializeObject<List<roleViewModel>>(jsonRoles);

            if (user != null)
            {
                var userRoles = await _user.GetRolesAsync(user);

                foreach (var role in myRoles)
                {
                    if (userRoles.Any(x => x == role.roleName.Trim()) && !role.useRole)
                    {
                        await _user.RemoveFromRoleAsync(user, role.roleName.Trim());
                    }

                    if (!userRoles.Any(x => x == role.roleName.Trim()) && role.useRole)
                    {
                        await _user.AddToRoleAsync(user, role.roleName.Trim());
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }
    }
}
