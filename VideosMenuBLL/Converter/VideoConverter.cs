﻿using System;
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
                Genres = vid.Genres?.Select(a => new BOGenre(){

                    Id = a.VideoId,
                    Name = a.Genres?.Name
                }).ToList(),
				Title = vid.Title,
				About = vid.About,
				Owner = vid.Owner
			};
		}

		internal Video Convert(BOVideo videoo)
		{
			if (videoo == null) { return null; }
            return new Video()
            {
                Id = videoo.Id,
                Genres = videoo.Genres.Select(a => new VideoGenre() { 

                    VideoId = a.Id,
                    GenreId = videoo.Id
                }).ToList(),
				Title = videoo.Title,
				About = videoo.About,
				Owner = videoo.Owner

			};
		}

	}
}
