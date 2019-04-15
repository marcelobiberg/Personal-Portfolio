using Biberg.MyPortfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biberg.MyPortfolio.Services.Profile
{
    interface IProfileManager
    {
        ApplicationUser CurrentUser { get; }
        bool IsHasPassword(ApplicationUser user);
        bool IsEmailConfirmed(ApplicationUser user);
        bool UpdateProfile(ApplicationUser user);
    }
}
