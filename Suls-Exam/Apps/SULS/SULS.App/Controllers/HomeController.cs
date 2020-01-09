using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Users;
using SULS.Services;
using System.Collections.Generic;
using System.Linq;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return Index();
        }

        public IActionResult Index()
        {
            if(!this.IsLoggedIn())
            {
                return this.View();
            }

            var problemsToPresent = this.problemsService.GetAllProblems().Select(x => new AllProblemsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count
            }).ToList();

            return this.View(problemsToPresent, "IndexLoggedIn");
        }
    }
}