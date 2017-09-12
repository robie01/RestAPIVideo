using System;
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

        public string AllInformation
            {
            
             get {return ($"{Title} {About} {Owner}"); }
			
            }



    }
}
