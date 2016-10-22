using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlueCaiCms.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BlueCaiCms.BLL;
using BlueCaiCms.Data.DataProvider;
using BlueCaiCms.Data.Dapper.Repositories;

namespace BlueCaiCms
{
    public class Startup
    {
        IConfigurationRoot configuration;

        //public Startup(IHostingEnvironment env)
        //{
        //    configuration = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json").Build();
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            DiConfig(services);
            services.AddMvc();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUi();
            app.UseMvcWithDefaultRoute();
        }

        private void DiConfig(IServiceCollection services)
        {
            //services.AddDbContext<BCDbContext>(option => option.UseSqlServer(configuration["Data:BlueCaiCms:ConnectionString"]));
            services.AddDbContext<BCDbContext>(option => option.UseSqlServer("Server=192.168.81.133;Database=BlueCaiCms;User ID=sa;Password=Caiqb@163.1989;Connection Timeout=30;"));
            services.AddTransient<StudentService>();
            services.AddTransient<ClassService>();
            services.AddTransient<IDataProvider, DataProvider>();
            services.AddTransient<ProductRepository>();
        }
    }
}
