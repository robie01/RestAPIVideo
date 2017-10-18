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
        GenreConverter gconv = new GenreConverter();

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

        public BOVideo Get(int Id)
        {
			using (var uow = facade.UnitOfWork)
			{
                //1. Get and convert the Video
                var vid = con.Convert(uow.VideoRepository.Get(Id));

                //2. Get All related Genres from GenresRepository using genresIds
                //3. Convert and Add the Genres to the BOVideo

                // we get All Genres information by getting only the id.
                /* vid.Genres = vid.GenresIds?
                 .Select(id => gconv.Convert(uow.GenreRepository.Get(id))).ToList();*/


					/*vid.Genres = uow.GenreRepository.GetAllById(vid.GenresIds)
					.Select(g => gconv.Convert(g)).ToList();*/
                                
				

                //4. Return the customer
                return vid;
			

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
                customerFromDb.Address = vid.Address;
                customerFromDb.Genres = videoUpdated.Genres;


                //1. Remove All, except the "old" ids we wanna keep (Avoid attached issues)

                //2. Remove All ids already in database from videoUpdated

                //3. Add All new VideoGenre not yet seen in the DB



                uow.Complete();
				return con.Convert(customerFromDb);
                
            }


        }

     

       
    }
}