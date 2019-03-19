using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Biberg.MyPortfolio.Data;
using Biberg.MyPortfolio.Services.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Biberg.MyPortfolio.Pages.Settings
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMailManager _emailSender;

        public ProfileModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMailManager emailSender) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        [Required]
        [Display(Name = "Nome")]
        public string UserName { get; set; }

        [BindProperty]
        [Display(Name = "E-mail")]
        [Required][EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Phone][Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        [BindProperty]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [Display(Name = "Atuação")]
        public string Role { get; set; }

        [BindProperty]
        [MaxLength(800, ErrorMessage = "Máximo de 800 caracteres")]
        [Display(Name = "Descrição")]
        public string AboutDescription { get; set; }

        [BindProperty]
        [MaxLength(300, ErrorMessage = "Máximo de 300 caracteres")]
        [Display(Name = "Github")]
        public string UrlGithub { get; set; }

        //[BindProperty]
        //public BoostNo Boost_No { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            UserName = user.UserName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Role = user.Role;
            AboutDescription = user.AboutDescription;
            UrlGithub = user.UrlGithub;

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null) throw new ApplicationException($"Não foi possível carregar usuário com ID Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            if (UserName != user.UserName)
            {
                var setUserNameResult = await _userManager.SetUserNameAsync(user, UserName);
                if (!setUserNameResult.Succeeded)
                {
                    TempData["StatusMessage"] = $"Error on changing username." + string.Join(". ", setUserNameResult.Errors.Select(p => p.Description));
                    return RedirectToPage();
                }
            }

            if (Email != user.Email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Email);
                if (!setEmailResult.Succeeded)
                {
                    TempData["StatusMessage"] = $"Error on changing email. '{Email}' use in other account and must be unique.";
                    return RedirectToPage();
                }
            }

            if (PhoneNumber != user.PhoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            await _userManager.UpdateAsync(user);

            TempData["StatusMessage"] = "Your profile has been updated";

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null) throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
            await _emailSender.SendEmailConfirmationAsync(user.Email, callbackUrl);

            TempData["StatusMessage"] = "Verification email sent. Please check your email.";

            return RedirectToPage();
        }
    }
}