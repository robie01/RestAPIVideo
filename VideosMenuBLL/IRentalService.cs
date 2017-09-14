using System;
using System.Collections.Generic;
using VideosMenuBLL.BO;

namespace VideosMenuBLL
{
    public interface IRentalService
    {
		//C
		BORental Create(BORental rent);

		//R
		List<BORental> GetAll();
		BORental Get(int Id);

		//U
		BORental Update(BORental rent);

		//D
		BORental Delete(int id);
    }
}
