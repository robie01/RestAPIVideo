﻿using System;
using System.Collections.Generic;
using System.Linq;
using VideosMenuDAL.Entities;
using VideosMenuDAL.Context;
using Microsoft.EntityFrameworkCore;

namespace VideosMenuDAL.Repositories
{
    public class VideoRepositoryEFMemory : IVideoRepository
    {
        InMemoryContext _context;

        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            _context = context;
        }

        public Video Create(Video vid)
        {
           
            _context.Videos.Add(vid);
            return vid;
        }

        public Video Delete(int id)
        {
            var video = Get(id);
            _context.Videos.Remove(video);
            return video;
        }

        public Video Get(int Id)
        {
            return _context.Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            // Genres inside the lambda expression is the Join table.
            return _context.Videos.Include(c => c.Genres)
                         /*  .ThenInclude(a => a.Genres) - for showing other prop of genre.*/
                           .ToList();
        }

       
    }
}
