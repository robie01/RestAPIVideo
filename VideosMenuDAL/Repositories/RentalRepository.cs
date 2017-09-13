using System;
using System.Collections.Generic;
using System.Linq;
using VideosMenuDAL.Context;
using VideosMenuDAL.Entities;

namespace VideosMenuDAL.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        InMemoryContext _context;
        public RentalRepository(InMemoryContext context)
        {
            _context = context;
        }

        public Rental Create(Rental rent)
        {
            _context.Rents.Add(rent);
            return rent;
        }

        public Rental Delete(int id)
        {
            var rent = Get(id);
            _context.Rents.Remove(rent);
            return rent;
        }

        public Rental Get(int Id)
        {
            return _context.Rents.FirstOrDefault(r => r.Id == Id);
        }

        public List<Rental> GetAll()
        {
            return _context.Rents.ToList();
        }
    }
}
