using System;
using System.Linq;
using VideosMenuBLL.BO;
using VideosMenuDAL.Entities;

namespace VideosMenuBLL.Converter
{
	public class VideoConverter
	{
        private GenreConverter gconv;

        public VideoConverter()
        {
            gconv = new GenreConverter();
        }

		internal BOVideo Convert(Video vid)
		{
            if (vid == null) { return null; }

            return new BOVideo()
            {
                Id = vid.Id,
                Genres= vid.Genres?.Select(a => new BOGenre(){

                    Id = a.VideoId,
                    Name = a.Genres?.Name,
                    Author = a.Genres?.Author

                }).ToList(),


               /* Genres= vid.Genres?.Select(a => new BOGenre()
                {

                    Id = a.VideoId,
                    Name = a.Genres?.Name,
                    Author = a.Genres?.Author
                }).ToList(),*/

				Title = vid.Title,
				About = vid.About,
				Owner = vid.Owner,
                Address = vid.Address
			};
		}

		internal Video Convert(BOVideo videoo)
		{
			if (videoo == null) { return null; }

            return new Video()
            {
                Id = videoo.Id,
                Genres = videoo.Genres?.Select(a => new VideoGenre() { 

                    GenreId = a.Id,
                    VideoId = videoo.Id
                }).ToList(),
				Title = videoo.Title,
				About = videoo.About,
				Owner = videoo.Owner,
                Address = videoo.Address

			};
		}

	}
}
