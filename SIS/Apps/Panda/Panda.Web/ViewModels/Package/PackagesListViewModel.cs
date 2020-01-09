using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Web.ViewModels.Package
{
    public class PackagesListViewModel
    {
        public IEnumerable<PackageViewModel> Packages { get; set; }
    }
}
