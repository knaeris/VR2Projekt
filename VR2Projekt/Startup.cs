using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore;
using VR2Projekt.Models;
using VR2Projekt.Services;
using DAL.App.EF.Repositories;
using DAL.App.Interfaces.Repositories;
using DAL.App.EF;
using Domain;
using DAL.App.Interfaces;
using DAL.Interfaces;
using DAL.App.Interfaces.Helpers;
using DAL.App.EF.Helpers;
using BL.Services;
using BL;
using BL.Factories;
using BL.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace VR2Projekt
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

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            services.Configure<IdentityOptions>(options =>
            {
                // VERY WEAK Password settings for testing
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6; // if you change this, then also update viewmodel atrributes
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthentication()
                .AddCookie(options => { options.SlidingExpiration = true; })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["Token:Issuer"],
                        ValidAudience = Configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["Token:Key"])
                            )
                    };
                   
                });


            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IBlogFactory, BlogFactory>();
            services.AddTransient<IBlogPostService, BlogPostService>();
            services.AddTransient<IBlogPostFactory, BlogPostFactory>();
            services.AddTransient<IBlogCommentService, BlogCommentService>();
            services.AddTransient<IBlogCommentFactory, BlogCommentFactory>();
            services.AddTransient<IBlogPostCommentService, BlogPostCommentService>();
            services.AddTransient<IBlogPostCommentFactory, BlogPostCommentFactory>();
            services.AddTransient<IBlogCategoryService, BlogCategoryService>();
            services.AddTransient<IBlogCategoryFactory, BlogCategoryFactory>();
            services.AddTransient<IFavoriteCategoryService, FavoriteCategoryService>();
            services.AddTransient<IFavoriteCategoryFactory, FavoriteCategoryFactory>();
            services.AddTransient<IFollowedBlogService, FollowedBlogService>();
            services.AddTransient<IFollowedBlogFactory, FollowedBlogFactory>();
            services.AddTransient<ILikedBlogService, LikedBlogService>();
            services.AddTransient<ILikedBlogFactory, LikedBlogFactory>();
            services.AddTransient<ILikedBlogPostService, LikedBlogPostService>();
            services.AddTransient<ILikedBlogPostFactory, LikedBlogPostFactory>();
            services.AddTransient<UserManager<ApplicationUser>>();
            //add repos to DI container
            services.AddScoped<IDataContext, ApplicationDbContext>();
            services.AddSingleton<IRepositoryFactory, EFRepositoryFactory>();
            services.AddScoped<IRepositoryProvider, EFRepositoryProvider>();
            services.AddScoped<IAppUnitOfWork, AppEFUnitOfWork>();

            #region add xml support
            //Respect browser headers
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true; // false by default
            });

            services.AddMvc().AddXmlSerializerFormatters();
            #endregion

            #region jsonconfiguration
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling
                            = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
                options.SerializerSettings.PreserveReferencesHandling
                            = Newtonsoft.Json.PreserveReferencesHandling.Objects;
                options.SerializerSettings.Formatting
                            = Newtonsoft.Json.Formatting.Indented;
            });
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            });


            services.AddMvc();


            //services.Configure<MvcOptions>(options =>
            //{
            //    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

           

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors("AllowAll");
            //app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
