using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VM.DataAccessLayer.Common;
using VM.DataAccessLayer.ViewModels.Management.WorkAgreements;

namespace VirtualManager.Controllers.Management
{
    public class AgreementController : CommonController<IWorkAgreementService>
    {
        public AgreementController(IWorkAgreementService service) : base(service) { }
        // GET: Agreement
        public ActionResult Index()
        {
            var agreementModel = _service.GetAgreements();
            return View(agreementModel);
        }
    }
}