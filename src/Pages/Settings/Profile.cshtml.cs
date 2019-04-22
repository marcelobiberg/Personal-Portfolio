using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyPortfolio.Data;
using MyPortfolio.Services.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPortfolio.Pages.Settings
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

        public bool IsEmailConfirmed { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null)
                throw new ApplicationException($"Não foi possível carregar o usuário ID '{_userManager.GetUserId(User)}'.");

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
            if (user == null) throw new ApplicationException($"Não foi possível carregar o usuário com ID'{_userManager.GetUserId(User)}'.");

            if (UserName != user.UserName)
            {
                var setUserNameResult = await _userManager.SetUserNameAsync(user, UserName);
                if (!setUserNameResult.Succeeded)
                {
                    TempData["StatusMessage"] = $"Não foi possível alterar o campo - Nome Completo." + string.Join(". ", setUserNameResult.Errors.Select(p => p.Description));
                    return RedirectToPage();
                }
            }

            if (Email != user.Email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Email);
                if (!setEmailResult.Succeeded)
                {
                    TempData["StatusMessage"] = $"Erro ao mudar o e-mail. '{Email}' Usado em outra conta e precisa ser único.";
                    return RedirectToPage();
                }
            }

            if (PhoneNumber != user.PhoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Erro inesperado ao configurar número do telefone para user ID '{user.Id}'.");
                }
            }

            user.Role = Role;
            user.AboutDescription = AboutDescription;
            user.UrlGithub = UrlGithub;
            await _userManager.UpdateAsync(user);

            TempData["StatusMessage"] = "Seu Profile foi atualizado";

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null) throw new ApplicationException($"Não foi possível carregar user ID '{_userManager.GetUserId(User)}'.");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
            await _emailSender.SendEmailConfirmationAsync(user.Email, callbackUrl);

            TempData["StatusMessage"] = "Verificação de envio de e-mail. Por favor verifique seu e-mail.";

            return RedirectToPage();
        }
    }
}