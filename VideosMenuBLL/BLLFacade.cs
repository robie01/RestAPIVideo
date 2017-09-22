using System;
using VideosMenuBLL.BO;
using VideosMenuBLL.Services;
using VideosMenuDAL;

namespace VideosMenuBLL
{
    public class BLLFacade
    {
        public IVideoService VideoService
        {
            get { return new VideoService(new DALFacade()); }
        }
        public IRentalService RentalService
		{
            get { return new RentalService(new DALFacade()); }
		}
        public IGenreService GenreService
		{
            get { return new GenreService(new DALFacade()); }
		}
    }
}
