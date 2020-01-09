using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Submissions;
using SULS.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(ISubmissionsService submissionsService)
        {
            this.submissionsService = submissionsService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var model = new GetSubmissionCreatePageModel
            {
                Name = submissionsService.GetProblemName(id),
                ProblemId = id
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateSubmissionInputModel input)
        {
            if(!ModelState.IsValid)
            {
                return this.Redirect($"/Submissions/Create?id={input.ProblemId}");
            }

            string userId = this.User.Id;

            this.submissionsService.CreateSubmission(input.ProblemId, input.Code, userId);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            this.submissionsService.Delete(id);

            return this.Redirect("/");
        }
    }
}
