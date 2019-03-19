using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biberg.MyPortfolio.Services.Mail
{
    public class MailManagerOptions
    {
        public string EmailProvider { get; set; }
        public string SupportTeamEmail { get; set; }
        public string SupportTeamName { get; set; }
    }
}
