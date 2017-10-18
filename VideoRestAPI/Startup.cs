using System;
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

                services.AddCors(o => o.AddPolicy("MyPolicy", builder =>{
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                 var facade = new BLLFacade();

				var genre1 = facade.GenreService.Create(new BOGenre()
				{
                    
					Name = "Horror  ",
                    Author = "Walkers"

				});


				var genre2 = facade.GenreService.Create(new BOGenre()
				{

					Name = "Suspence   ",
					Author = "Blob"

				});

                
              

               var video = facade.VideoService.Create(new BOVideo() 
                { 
                    Title = "Good day",
                    About = "You dont want to know",
                    Owner = "Robie",
                    Address = "Sælhundevej 97",
                    Genres = new List<BOGenre>() { genre1 }

                });

			    facade.VideoService.Create(new BOVideo()
				{
					Title = "Computer Science",
					About = "Programming",
					Owner = "Finnur",
                    Address ="Denmark",
                    Genres = new List<BOGenre>() { genre2 }

				});
                for (int i = 0; i < 5; i++)   {
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
