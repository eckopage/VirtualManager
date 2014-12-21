using System.Collections.Generic;
using System.Web.Mvc;

namespace VM.DataAccessLayer.Common {
    /// <summary>
    /// Represent common base class for all MVC controllers wchich require database to use.
    /// </summary>
    /// <typeparam name="T">Public service abstraction to use IoC.</typeparam>
    public abstract class CommonController<T> : CommonController where T : IService {
        protected T _service;

        protected CommonController(T service) {
            _service = service;
        }

        protected void AddErrors(IEnumerable<string> errors) {
            foreach(var error in errors)
                this.ModelState.AddModelError("", error);
        }
    }

    public abstract class CommonController : Controller {
        protected void AddErrors(IEnumerable<string> errors) {
            foreach(var error in errors)
                this.ModelState.AddModelError("", error);
        }
    }
}
