using System;
using System.Collections.Generic;
using System.Linq;
using VideosMenuBLL.BO;
using VideosMenuBLL.Converter;
using VideosMenuDAL;

namespace VideosMenuBLL.Services
{
    public class GenreService : IGenreService
    {
        GenreConverter conv;

        DALFacade facade;

        public GenreService(DALFacade facade)
        {
            this.facade = facade;
            conv = new GenreConverter();
        }

        public BOGenre Create(BOGenre genre)
        {
            // using - invoke the dipose function. Make sure that we aren't connected to anything and database is closed.
            using(var uow = facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Create(conv.Convert(genre));
                uow.Complete();
                return conv.Convert(genreEntity);
            }
        }

        public BOGenre Delete(int id)
        {
			using (var uow = facade.UnitOfWork)
			{
                var genreEntity = uow.GenreRepository.Delete(id);
				uow.Complete();
				return conv.Convert(genreEntity);
			}
        }

        public BOGenre Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Get(Id);
                return conv.Convert(genreEntity);
            }
        }

        public List<BOGenre> GetAll()
        {
			using (var uow = facade.UnitOfWork)
			{
                return uow.GenreRepository.GetAll().Select(conv.Convert).ToList();
			} 
        }

        public BOGenre Update(BOGenre rent)
        {
			using (var uow = facade.UnitOfWork)
			{
                var genreEntity = uow.GenreRepository.Get(rent.Id);
                if(genreEntity == null)
                {
                    throw new InvalidOperationException("Genre not found");
                }
                uow.Complete();
                return conv.Convert(genreEntity);
			}
        }
    }
}
