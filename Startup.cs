using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScoreStack.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreStack
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
            services
                .AddSession(opt=> {
                    opt.Cookie.Name = "hpzq";
                    opt.IdleTimeout = new TimeSpan(0, 0, 30);
                    
                })
                .AddRazorPages()
                //.AddMvcOptions(m=>m.Filters.Add<NeedLogOnAttribute>(/*typeof( NeedLogOnAttribute)*/))//全局过滤配置Filters
                .AddRazorPagesOptions(opt =>
                {
                    opt.Conventions.AddPageRoute("/Log/On", "/LogOn");
                    //opt.Conventions.AddPageRoute("/Article/Index", "/Article/Category-{id:int}");

                    //opt.Conventions.AddPageRoute("/Article/Single", "/Article/{id?}");//?的意思是不管Article/后有没有id，都走/Article/Single这个url
                    opt.Conventions.AddPageRoute("/Article/Single", "/Article/{id:int}");

                    opt.Conventions.AddPageRoute("/Article/index", "/Article/Page-{id:int}");
                });

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();//session配置

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
