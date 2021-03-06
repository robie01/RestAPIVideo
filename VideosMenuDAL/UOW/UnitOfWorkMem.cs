﻿using System;
using VideosMenuDAL.Context;
using VideosMenuDAL.Repositories;

namespace VideosMenuDAL.UOW
{
	public class UnitOfWorkMem : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
		public IGenreRepository GenreRepository { get; internal set; }
        public IRentalRepository RentalRepository { get; internal set; }
       

        private InMemoryContext context;

        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            context.Database.EnsureCreated();

            VideoRepository = new VideoRepositoryEFMemory(context);
            GenreRepository = new GenreRepository(context);
            RentalRepository = new RentalRepository(context);
        }


        public int Complete()
        {
            // the int in this method is the number of Objects written in the underlying database.
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
