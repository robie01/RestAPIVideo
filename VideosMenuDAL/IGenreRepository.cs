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
        IEnumerable<Genre> GetAllById(List<int> ids);
		Genre Get(int Id);


		//D
		Genre Delete(int id);
    }
}
