using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using IntProg.Models;

namespace IntProg.Controllers
{
    public class StartpController : Controller
    {
        private readonly tiyatroContext _dbContext;

        public StartpController(tiyatroContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            if (claimuser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login logincs)
        {
            var user = await _dbContext.Logins.FirstOrDefaultAsync(u => u.Email == logincs.Email && u.Password == logincs.Password);

            if (user != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Email),
                    new Claim("Diğer özellikler", "Örnek Rol")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties prop = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = logincs.LoggedStatus
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), prop);

                return RedirectToAction("Index", "Home");
            }

            ViewData["OnayMesaji"] = "Kullanıcı bulunamadı";
            return View();
        }
    }
}
