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
