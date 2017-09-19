﻿using System;
namespace VideosMenuBLL.BO
{
    public class BORental
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
        public int VideoId
        {
            get;
            set;
        }
        public BOVideo  Video
        {
            get;
            set;
        }
    }
}
