using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Problems
{
    public class DetailsViewModel
    {
        public string Name { get; set; }

        public ICollection<ProblemsViewModel> Submissions { get; set; }
    }
}
