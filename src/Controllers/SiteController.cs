using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Data;
using Microsoft.AspNetCore.Hosting;
using MyPortfolio.Models.SiteViewModel;
using System.IO;

namespace MyPortfolio.Controllers
{
    public class SiteController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public SiteController(ApplicationDbContext context,
            IHostingEnvironment env,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _hostingEnvironment = env;
            _Context = context;
        }

        private bool UserExists()
        {
            return _Context.User.Any();
        }

        //Core jedi
        #region Index do Site
        public async Task<IActionResult> Index()
        {
            var MainSite = new MainSiteViewModel();

            if (!UserExists())
            {
                MainSite = new MainSiteViewModel
                {
                    //Inicio
                    Name = "Bill Gates",
                    Role = "CEO Microsoft",

                    //Modelo da zueira
                    AboutDescription = "Seja a melhor versão de você mesmo -Bill Gates",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Name = "C#",
                            Score = 100,
                        },
                        new Skill
                        {
                            Name = "SQL Server",
                            Score = 100,
                        },

                            new Skill
                        {
                            Name = "AZURE",
                            Score = 100,
                           ShortDescription = "É claro que darei computadores aos meus filhos, mas antes darei livros"
                        }

                    },
                    Projects = new List<Project>
                    {
                        new Project
                        {
                            Title = "Windows 11 Professional",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ",
                            ImagePath = Path.Combine(_hostingEnvironment.WebRootPath,"/Img/Project/4574ba4f-4245-4b24-bcc4-d4eaeb2e433c.jpg"),
                            UrlProject = "www.teste.com.br"
                        }
                    }
                };

                var userName = "Marcelo Biberg";
                var email = "biberg.marcelo@gmail.com";
                var pass = "Example123456@!";

                var userSeed = new ApplicationUser
                {
                    UserName = userName,
                    Email = email,
                    Role = "Developer",
                    AboutDescription = "Faça mais do que existir"
                };

                var result = await _userManager.CreateAsync(userSeed, pass);
                if (result.Succeeded)
                {
                    return View(MainSite);
                }

                return View();
            }

            var user = _Context.User.FirstOrDefault();
            List<Skill> skills = _Context.Skills.ToList();
            List<Project> projects = _Context.Project.ToList();

            MainSite = new MainSiteViewModel
            {
                Name = user.UserName,
                Role = user.Role,
                AboutDescription = user.AboutDescription,
                Skills = skills,
                Projects = projects
            };
            return View(MainSite);

        }
        #endregion
    }
}
