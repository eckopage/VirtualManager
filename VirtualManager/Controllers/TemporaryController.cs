using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VM.DataAccessLayer.Common;
using VM.DataAccessLayer.ViewModels;
using VM.DataAccessLayer.ViewModels.Temporary;
using VM.ReCaptcha;
using libLogger;

namespace VirtualManager.Controllers {
    public class TemporaryController : CommonController<ITemporaryService> {
        public TemporaryController(ITemporaryService service) : base(service) { }

        public ActionResult Index() {
            var model = _service.GetTemporary();
            
           // libLogger.IVMLogger logger = new libLogger.VMLogger();
           // logger.Info("test sfdfsdsd");

            return this.View(model);
        }
    }
}