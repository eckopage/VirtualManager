using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.ReCaptcha.Helpers {
    [Captcha]
    public interface IReCaptchaViewModel {
        string recaptcha_response_field { get; set; }

        string recaptcha_challenge_field { get; set; }
    }
}
