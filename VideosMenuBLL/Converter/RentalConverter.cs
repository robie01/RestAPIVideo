using System;
using VideosMenuBLL.BO;
using VideosMenuDAL.Entities;

namespace VideosMenuBLL.Converter
{
    public class RentalConverter
    {
		
		/// <summary>
		/// 
		/// This happens when user retrieves data from database back to Rest API
		/// </summary>
		/// <returns>The convert.</returns>
		/// <param name="genre">Genre.</param>
		internal BORental Convert(Rental rent)
		{
            return new BORental()
			{
				Id = rent.Id,
                DeliveryDate = rent.DeliveryDate,
                RentalDate = rent.RentalDate
			};
		}

		/// <summary>
		/// Sending/saving data to database.
		/// </summary>
		/// <returns>The convert.</returns>
		/// <param name="gen">Gen.</param>
        internal Rental Convert(BORental rent)
		{
            return new Rental()
			{
				Id = rent.Id,
                DeliveryDate = rent.DeliveryDate,
                RentalDate = rent.RentalDate
			};

		}
    }
}
