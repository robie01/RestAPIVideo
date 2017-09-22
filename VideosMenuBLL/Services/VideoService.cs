using System;
using System.Collections.Generic;
using System.Linq;
using VideosMenuBLL.BO;
using VideosMenuBLL.Converter;
using VideosMenuDAL;
using VideosMenuDAL.Entities;

namespace VideosMenuBLL.Services
{

    public class VideoService : IVideoService // This means the actual VideoService class should have all the implementation from IVideoService
    {
        VideoConverter con = new VideoConverter();

        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public BOVideo Create(BOVideo vid)
        {
            using(var uow = facade.UnitOfWork) // using keyword is calling the disposable. Once it exited the curly braces then it will aut. dispose.
            {

                var Video = uow.VideoRepository.Create(con.Convert(vid));
                uow.Complete();
                return con.Convert(Video);
                
            }
           
           
        }
        public void CreateAll(List<BOVideo> videos)
        {
            using (var uow = facade.UnitOfWork)
            {
                foreach (var video in videos)
                {
                    uow.VideoRepository.Create(con.Convert(video));
                }
            }
        }



        public BOVideo Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
               
                var Video = uow.VideoRepository.Delete(id);
				uow.Complete();
				return con.Convert(Video);

            }
        }

        public BOVideo Get(int id)
        {
			using (var uow = facade.UnitOfWork)
			{
                return con.Convert(uow.VideoRepository.Get(id));
			

			}
        }


        public List<BOVideo> GetAll()
        {
			using (var uow = facade.UnitOfWork)
			{
               
                /* var newList = new List<BOVideo>();
                foreach (var v in uow.VideoRepository.GetAll())
                {
                    newList.Add(Convert(v));
                }*/


                return uow.VideoRepository.GetAll().Select(v => con.Convert(v)).ToList(); 


			}
        }


        public BOVideo Update(BOVideo vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customerFromDb = uow.VideoRepository.Get(vid.Id); // ?????
				if (customerFromDb == null)
				{
					throw new InvalidOperationException("Video not found");
				}

                var videoUpdated = con.Convert(vid);
				customerFromDb.Title = vid.Title;
				customerFromDb.About = vid.About;
				customerFromDb.Owner = vid.Owner;
                customerFromDb.Genres = videoUpdated.Genres;
                uow.Complete();
				return con.Convert(customerFromDb);
                
            }


        }

     

       
    }
}