using System;
using System.Collections.Generic;
using System.Linq;
using VideosMenuDAL.Context;
using VideosMenuDAL.Entities;

namespace VideosMenuDAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {

        InMemoryContext _context;

        public GenreRepository(InMemoryContext context)
        {
            _context = context;
        }
        public Genre Create(Genre vid)
        {
            _context.Genres.Add(vid);
            return vid;
        }

        public Genre Delete(int id)
        {
            var genre = Get(id);
            _context.Genres.Remove(genre);
            return genre;

        }

        public Genre Get(int Id)
        {
            return _context.Genres.FirstOrDefault(g => g.Id == Id);
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }
    }
}
