using Panda.Services;
using Panda.Web.ViewModels.Receipt;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Web.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var viewModel = this.receiptsService.GetAll().Select(r => new ReceiptViewModel
            {
                Id = r.Id,
                Fee = r.Fee,
                IssuedOn = r.IssuedOn,
                RecipientName = r.Recipient.Username
            }).ToList();

            return this.View(viewModel);
        }
    }
}
