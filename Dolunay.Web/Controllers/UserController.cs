using Dolunay.Models;
using Dolunay.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Dolunay.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AppUser appUser)
        {
            AppUser user = _unitOfWork.Users.GetAll(x => x.Email == appUser.Email &&
            x.Password == appUser.Password).Include(x=>x.UserType).ToList().First();
            if (user == null)
            {
                // User null değilse bu kişiyi login etmemiz yani
                // cookie authentication işlemleri yapmamız gerekiyor

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Email));
                claims.Add(new Claim(ClaimTypes.Role, user.UserType.Name));
                claims.Add(new Claim(ClaimTypes.GivenName, user.Name));
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Login");

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
                    ClaimsPrincipal(claimsIdentity));

                return Ok("Giriş başarılı");
            }

            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");

            }

        }
    }
}
