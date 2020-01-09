using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Submissions
{
    public class CreateSubmissionInputModel
    {
        [RequiredSis]
        public string ProblemId { get; set; }

        [RequiredSis]
        [StringLengthSis(30, 800, "Code lenght should be between 30 and 800 symbols")]
        public string Code { get; set; }
    }
}
