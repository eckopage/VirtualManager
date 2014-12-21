using System.ComponentModel.DataAnnotations;
using VM.ReCaptcha.Helpers;

namespace VM.DataAccessLayer.ViewModels.Accounts.Registration {
    /// <summary>
    /// Represent ViewModel of registration view.
    /// </summary>
    public class RegisterViewModel : IReCaptchaViewModel {
        [Required]
        [EmailAddress]
        [Display(Name = "Podaj email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Przepisz tekst z obrazka")]
        public string recaptcha_response_field { get; set; }

        public string recaptcha_challenge_field { get; set; }
    }
}
