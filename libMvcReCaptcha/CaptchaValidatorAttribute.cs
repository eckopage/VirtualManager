using System.Web.Mvc;
using System.Configuration;

namespace VM.ReCaptcha {
    /// <summary>
    /// <see cref="http://mvcrecaptcha.codeplex.com"/>
    /// <see cref="https://developers.google.com/recaptcha/docs/asp?hl=pl"/>
    /// </summary>
    internal class CaptchaValidatorAttribute : ActionFilterAttribute {
        private const string ChallengeFieldKey = "recaptcha_challenge_field";
        private const string ResponseFieldKey = "recaptcha_response_field";

        /// <summary>
        /// Called before the action method is invoked
        /// </summary>
        /// <param name="filterContext">Information about the current request and action</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var captchaChallengeValue = filterContext.HttpContext.Request.Form[ChallengeFieldKey];
            var captchaResponseValue = filterContext.HttpContext.Request.Form[ResponseFieldKey];
            var isValid = CaptchaValidatorAttribute.IsValid(captchaChallengeValue, captchaResponseValue, filterContext.HttpContext.Request.UserHostAddress);
            filterContext.ActionParameters["captchaValid"] = isValid;
            base.OnActionExecuting(filterContext);
        }

        public static bool IsValid(string source, string response, string userHostAddress = "::1"){
            var captchaValidtor = new Recaptcha.RecaptchaValidator {
                PrivateKey = ConfigurationManager.AppSettings["ReCaptchaPrivateKey"],
                RemoteIP = userHostAddress,
                Challenge = source,
                Response = response
            };

            var recaptchaResponse = captchaValidtor.Validate();
            return recaptchaResponse.IsValid;
        }
    }
}