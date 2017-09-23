﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VideosMenuBLL;
using VideosMenuBLL.BO;

namespace VideoRestAPI
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                 var facade = new BLLFacade();

				var genre = facade.GenreService.Create(new BOGenre()
				{
                    
					Name = "Horror",
                    Author = "Walkers"

				});
               var video = facade.VideoService.Create(new BOVideo() 
                { 
                    Title = "I love u",
                    About = "Love Story",
                    Owner = "Robie",
                    Genres = new List<BOGenre>() { genre }

                });
               
                for (int i = 0; i < 1000; i++)   {
                    facade.RentalService.Create(
                        new BORental()
                    {

                        DeliveryDate = DateTime.Now.AddMonths(1),
                        RentalDate = DateTime.Now.AddMonths(-1),
                        VideoId = video.Id

                    });
                }
            }

            app.UseMvc();
        }
    }
}
