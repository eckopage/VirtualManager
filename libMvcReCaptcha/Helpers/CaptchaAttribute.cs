using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.ReCaptcha.Helpers {
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    internal class CaptchaAttribute : ValidationAttribute {
        public override bool IsValid(object value) {
            return this.IsValid(value as IReCaptchaViewModel);
        }

        private bool IsValid(IReCaptchaViewModel value) {
            if(value != null && CaptchaValidatorAttribute.IsValid(value.recaptcha_challenge_field, value.recaptcha_response_field))
                return true;

            this.ErrorMessage = "Niepoprawny tekst z obrazka";
            return false;
        }
    }
}
