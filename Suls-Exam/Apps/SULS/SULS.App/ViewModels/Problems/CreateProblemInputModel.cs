using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Problems
{
    public class CreateProblemInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Problem name must be between 5 and 20 symbols")]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50, 300, "Total points must be between 50 and 300")]
        public int Points { get; set; }
    }
}
