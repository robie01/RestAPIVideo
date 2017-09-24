using System;
using VideosMenuBLL.BO;
using VideosMenuDAL.Entities;

namespace VideosMenuBLL.Converter
{
    public class GenreConverter
    {
        /// <summary>
        /// 
        /// This happens when user retrieves data from database back to Rest API
        /// </summary>
        /// <returns>The convert.</returns>
        /// <param name="genre">Genre.</param>
        internal BOGenre Convert(Genre genre)
        {
           
            if (genre == null) { return null; }
			return new BOGenre()
			{
                Id = genre.Id,
                Name = genre.Name,
                Author = genre.Author
			};
        }

        /// <summary>
        /// Sending/saving data to database.
        /// </summary>
        /// <returns>The convert.</returns>
        /// <param name="gen">Gen.</param>
        internal Genre Convert(BOGenre gen)
        {
            if (gen == null) { return null; }
            return new Genre()
            {
                Id = gen.Id,
                Name = gen.Name,
				Author = gen.Author
            };
            
        }
    }
}
