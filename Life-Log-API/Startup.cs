using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Life_Log_API.Services;
using Life_Log_API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Life_Log_API.Models;

namespace Life_Log_API
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
            services.AddSingleton<IConsumablesService, ConsumablesService>();
            services.AddSingleton<IConsumablesRepository, ConsumablesRepository>();
            services.AddSingleton<IEnumerable<Consumable>>(new Consumable[]{
                    new Consumable {Id = 0, Name = "Buffalo Wings", CreatedAt = new DateTime(2018, 3, 23), Quantity = 12, Unit = "Pieces", ImmediateRating = 0, PostRating = 0},
                    new Consumable { Id = 0, Name = "Podcasts", CreatedAt = new DateTime(2018, 3, 23), Quantity = 12, Unit = "Pieces", ImmediateRating = 0, PostRating = 0},
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
