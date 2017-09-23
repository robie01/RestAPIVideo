using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VideosMenuBLL.BO
{
    public class BOVideo
    {

        public int Id
        {
            get;
            set;
        }

        [Required]
        [MaxLength(10)]
        [MinLength(3)]
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

        /// <summary>
        /// Gets or sets the genres. Many to many relation.
        /// </summary>
        /// <value>The genres.</value>
        public List<BOGenre> Genres
        {
            get;
            set;
        }



        public string AllInformation
        {

            get { return ($"{Title} {About} {Owner}"); }

        }



    }
}
