using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HRResorcesVlada.Entities;
using Microsoft.EntityFrameworkCore;
using HRResorcesVlada.Services;

namespace HRResorcesVlada
{
    public class Startup
    {
       
       
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=HrResorcesDB;Trusted_Connection=true;";
            services.AddDbContext<HrResorcesContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<HrResorcesInterface, HrResorcesRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            HrResorcesContext HrResorcesContext)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            HrResorcesContext.EnsureSeedDataForContext();
            app.UseStatusCodePages();



            AutoMapper.Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<Entities.Company, Models.CompaniesWithoutJobPositionDto>().ReverseMap();

            });
            

            app.UseMvc();


          /*  app.Run( (context) =>
            {
                throw new Exception("exeption");
            });*/
        }
    }
}
