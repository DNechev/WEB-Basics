using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Users;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService usersService;

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }
        public IActionResult Login()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LogInInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.usersService.GetUserOrNull(input.Username, input.Password);

            if(user == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(user.Id, user.Username, user.Email);
            return this.Redirect("/");
        }

        [HttpPost]
        public IActionResult Register(RegisterUserInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            string userId = this.usersService.CreateUser(input.Username, input.Email, input.Password);
            this.SignIn(userId, input.Username, input.Email);

            return this.Redirect("/");
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}