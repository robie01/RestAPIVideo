using System;
using System.Collections.Generic;

namespace VideosMenuBLL.BO
{
    public interface IGenreService
    {
		//C
        BOGenre Create(BOGenre genre);

		//R
        List<BOGenre> GetAll();
		BOGenre Get(int Id);

		//U
		BOGenre Update(BOGenre rent);

		//D
		BOGenre Delete(int id);
    }
}

