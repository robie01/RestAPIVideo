using System;
using System.Collections.Generic;

namespace VideosMenuDAL.Entities
{
    public class Video
    {

        public int Id
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }

        public string About
        {
            get;
            set;
        }

        public string Owner
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }

        public List<Rental> Rentals
        {
            get;
            set;
        }
        public List<VideoGenre> Genres
        {
            get;
            set;
        }

    }
}
