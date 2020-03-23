using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMvcAuth4.CustomTokenProviders;
using ApiMvcAuth4.CustomValdiators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using ApiMvcAuth4.Data;
using ApiMvcAuth4.EmailService;
using ApiMvcAuth4.Factory;
using ApiMvcAuth4.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiMvcAuth4
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
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));
            
            // services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //     .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<User, IdentityRole>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequiredLength = 6;
                    config.Password.RequireUppercase = false;

                    config.User.RequireUniqueEmail = true;

                    config.SignIn.RequireConfirmedEmail = true;

                    config.Lockout.AllowedForNewUsers = true;
                    config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                    config.Lockout.MaxFailedAccessAttempts = 3;


                    config.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
                    

                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddTokenProvider<EmailConfirmationTokenProvider<User>>("emailconfirmation")
                .AddPasswordValidator<CustomPasswordValidator<User>>();





            // set 2 hours for the reset token provider life time
            services.Configure<DataProtectionTokenProviderOptions>(config =>
                config.TokenLifespan =TimeSpan.FromHours(2));
            
            
            // set 3 days for the confirmation token provider life time
            services.Configure<DataProtectionTokenProviderOptions>(config =>
                config.TokenLifespan =TimeSpan.FromDays(3));
            
            
            
            services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomClaimsFactory>();
            
            
            // register email service
            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            
            
            services.AddAuthentication()
                .AddGoogle("google" , config =>
                {
                    var googleAuth = Configuration.GetSection("Authentication:Google");
            
                    config.ClientId = googleAuth["ClientId"];
                    config.ClientSecret = googleAuth["ClientSecret"];
                    config.SignInScheme = IdentityConstants.ExternalScheme;
                });



            
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}