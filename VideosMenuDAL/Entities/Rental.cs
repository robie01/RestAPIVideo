using System;
using System.Collections.Generic;

namespace VideosMenuDAL.Entities
{
    public class Rental
    {
        public int Id
        {
            get;
            set;
        }

        public DateTime RentalDate
        {
            get;
            set;
        }

        public DateTime DeliveryDate
        {
            get;
            set;
        }
        public List<Genre> Genres
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the video identifier.
        /// </summary>
        /// <value>The video identifier.</value>
        public int VideoId
        {
            get;
            set;
        }
        public Video Video
        {
            get;
            set;
        }
    }
}
