using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biberg.MyPortfolio.Data;
using Microsoft.AspNetCore.Hosting;
using Biberg.MyPortfolio.Models.SiteViewModel;
using Biberg.MyPortfolio.Models;
using System.IO;

namespace Biberg.MyPortfolio.Controllers
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

        //Core jedi
        #region Index do Site
        public async Task<IActionResult> Index()
        {
            //Limpa todos os cookies ao iniciar a página
            //foreach (var cookie in Request.Cookies.Keys)
            //{
            //    Response.Cookies.Delete(cookie);
            //}

            //ID do user logado
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var MainSite = new MainSiteViewModel
                {
                    //Inicio
                    Name = user.UserName,
                    Role = user.Role,
                    //Sobre Mim
                    AboutDescription = user.AboutDescription,
                    Skills = user.Skills,
                    //Projetos
                    Projects = user.Projects

                };
                return View(MainSite);
            }
            //Cria modelo padrão da zueira
            else
            {
                var MainSite = new MainSiteViewModel
                {
                    //Inicio
                    Name = "Bill Gates",
                    Role = "CEO Microsoft",

                    //Sobre Mim
                    AboutDescription = "Não Brinque com o Nerd de sua Turma, pois um dia ele pode ser seu chefe. -Bill Gates",
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
                    },
                    ProjectTypes = new List<ProjectTypes>
                    {
                        new ProjectTypes
                        {
                            Name = "Developer"
                        }
                    }
                };
                return View(MainSite);
            }
        }
        #endregion
    }
}
