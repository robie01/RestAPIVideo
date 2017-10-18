using System;
using System.Collections.Generic;

namespace VideosMenuDAL.Entities
{
    public class Genre
    {
       public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }
        public List<VideoGenre> Videos
		{
			get;
			set;
		}
      
    }

}
