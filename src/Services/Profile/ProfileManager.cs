using MyPortfolio.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;

namespace MyPortfolio.Services.Profile
{
    public class ProfileManager : IProfileManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        private ApplicationUser _currentUser;

        public ProfileManager(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Usuário logado
        public ApplicationUser CurrentUser
        {
            get
            {
                if (_currentUser == null)
                    _currentUser = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;

                return _currentUser;
            }
        }
        #endregion

        #region Verifica se usuário já possui senha
        public bool IsHasPassword(ApplicationUser user)
        {
            return _userManager.HasPasswordAsync(user).Result;
        }
        #endregion

        #region Verifica se e-mail foi confirmado
        public bool IsEmailConfirmed(ApplicationUser user)
        {
            return _userManager.IsEmailConfirmedAsync(user).Result;
        }
        #endregion

        #region Atualiza usuário
        public bool UpdateProfile(ApplicationUser user)
        {
            if (user == null)
            {
                return false;
            }

            try
            {
                _userManager.UpdateAsync(user);
                _logger.LogInformation("Profile atualizado com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Falha na atualização do Profile", ex.InnerException);
                return false;
            }
        }
        #endregion
    }
}
