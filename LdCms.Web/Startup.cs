﻿using System;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LdCms.Web
{
    using Autofac;
    using LdCms.EF.DbEntitiesContext;
    using LdCms.Common.Extension;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //配置 Session、Cookies、Cache
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromSeconds(7200);
            });
            //配置数据库链接DI
            //services.AddDbContext<LdCmsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            services.AddEntityFrameworkSqlServer().AddDbContext<LdCmsDbEntitiesContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
            }, ServiceLifetime.Scoped);
            services.Configure<EF.DbConfig.ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<Models.SiteConfig>(Configuration.GetSection("SiteConfig"));

            
            //配置读写配置文件
            services.AddSingleton<IConfiguration>(Configuration);
            //配置http body
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //跨域请求 API
            //.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials()
            var urls = Configuration["AppCors:Url"].Split(",");
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSameDomain",
                    builder => builder.WithOrigins(urls));
            });

            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));

            //系统默认MVC配置
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //API版本控制DI
            services.AddApiVersioning(option => {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseSession();
            app.UseStaticHttpContext();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //app.UseCors("AllowSameDomain");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// Autofac容器注册
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }


    }
}
