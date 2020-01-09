using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.Data;
using SULS.Models;
using SULS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly SULSContext db;

        public ProblemsController(IProblemsService problemsService, SULSContext db)
        {
            this.problemsService = problemsService;
            this.db = db;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateProblemInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemsService.CreateProblem(input.Name, input.Points);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var problem = this.problemsService.GetProblemById(id);

            DetailsViewModel model = new DetailsViewModel
            {
                Name = problem.Name,
                Submissions = this.db.Submissions.Where(s => s.ProblemId == problem.Id)
                .Select(x => new ProblemsViewModel
                {
                    CreatedOn = x.CreatedOn,
                    SubmissionId = x.Id,
                    AchievedResult = x.AchievedResult,
                    MaxPoints = problem.Points,
                    Username = x.User.Username
                }).ToList()
            };

            return this.View(model);
        }

    }
}
