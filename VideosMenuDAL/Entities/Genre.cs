using System;
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
		public Video Video
		{
			get;
			set;
		}
    }

}
