using System;
namespace VideosMenuDAL.Entities
{
    public class VideoGenre
    {
        public int VideoId
        {
            get;
            set;
        }
		public Video Videos
		{
			get;
			set;
		}
        public int GenreId
        {
            get;
            set;
        }
      
        public Genre Genres
        {
            get;
            set;
        }
    }
}
