using System;
using System.Collections.Generic;
using VideosMenuDAL.Entities;

namespace VideosMenuDAL
{
    public interface IRentalRepository
    {
		//C
		Rental Create(Rental vid);

		//R
		List<Rental> GetAll();
		Rental Get(int Id);


		//D
		Rental Delete(int id);
    }
}
