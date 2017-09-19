using System;
namespace VideosMenuDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository 
        {
            get;
        }

		IGenreRepository GenreRepository
		{
			get;
		}
        IRentalRepository RentalRepository
        {
            get;
        }
       

        int Complete();
    }
}
