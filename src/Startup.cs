using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyPortfolio.Data;
using MyPortfolio.Services;
using MyPortfolio.Services.Mail;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.CookiePolicy;
using MyPortfolio.Models;
using MyPortfolio.Services.Profile;

namespace MyPortfolio
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;    // уникальный email
                config.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+"; 
                config.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            if (Configuration["Authentication:Facebook:IsEnabled"] == "true")
            {
                services
                    .AddAuthentication()
                    .AddFacebook(facebookOptions => {
                        facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                        facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                    });
            }

            if (Configuration["Authentication:Google:IsEnabled"] == "true")
            {
                services
                    .AddAuthentication()
                    .AddGoogle(googleOptions => {
                        googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                        googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                    });
            }

            services.AddTransient<Contact>();

            services.AddTransient<IProfileManager,ProfileManager>();

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/");

                    options.Conventions.AddPageRoute("/Site/Index", "");

                    options.Conventions.AllowAnonymousToPage("/Error");
                    options.Conventions.AllowAnonymousToPage("/Account/AccessDenied");
                    options.Conventions.AllowAnonymousToPage("/Account/ConfirmEmail");
                    options.Conventions.AllowAnonymousToPage("/Account/ExternalLogin");
                    options.Conventions.AllowAnonymousToPage("/Account/ForgotPassword");
                    options.Conventions.AllowAnonymousToPage("/Account/ForgotPasswordConfirmation");
                    options.Conventions.AllowAnonymousToPage("/Account/Lockout");
                    options.Conventions.AllowAnonymousToPage("/Account/Login");
                    options.Conventions.AllowAnonymousToPage("/Account/Register");
                    options.Conventions.AllowAnonymousToPage("/Account/ResetPassword");
                    options.Conventions.AllowAnonymousToPage("/Account/ResetPasswordConfirmation");
                    options.Conventions.AllowAnonymousToPage("/Account/SignedOut");
                    options.Conventions.AllowAnonymousToPage("/Site/Index");
                });

            services.Configure<MailManagerOptions>(Configuration.GetSection("Email"));

            if (Configuration["Email:EmailProvider"] == "SendGrid")
            {
                services.Configure<SendGridAuthOptions>(Configuration.GetSection("Email:SendGrid"));
                services.AddSingleton<IMailManager, SendGridMailManager>();
            }
            else
            {
                services.AddSingleton<IMailManager, EmptyMailManager>();
            }

            services.AddScoped<Services.Profile.ProfileManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Site}/{action=Index}");
            });

        }
    }
}
