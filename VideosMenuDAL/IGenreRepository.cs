using System;
using System.Collections.Generic;
using VideosMenuDAL.Entities;

namespace VideosMenuDAL
{
    public interface IGenreRepository
    {

        //C
        Genre Create(Genre vid);

        //R
        List<Genre> GetAll();
		Genre Get(int Id);


		//D
		Genre Delete(int id);
    }
}
