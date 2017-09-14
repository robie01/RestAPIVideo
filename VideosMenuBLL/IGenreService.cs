using System;
using System.Collections.Generic;
using VideosMenuBLL.BO;

namespace VideosMenuBLL
{
    public class IGenreService
    {

		public interface IVideoService
		{
			//C
			BOGenre Create(BOGenre genre);

			//R
			List<BOGenre> GetAll();
			BOGenre Get(int Id);

			//U
			BOGenre Update(BOVideo genre);

			//D
			BOGenre Delete(int id);
		}
    }
}
