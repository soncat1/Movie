using Movie.DAL;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        private MovieContext db;
        public CinemaRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Add(Cinema item)
        {
            db.Cinemas.Add(item);
        }

        public void Delete(int id)
        {
            var cinema = db.Cinemas.Find(id);
            if (cinema != null)
            {
                db.Cinemas.Remove(cinema);
            }

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public ICollection<Cinema> GetAll()
        {
            return db.Cinemas.ToList();
        }

        public Cinema GetObject(object obj)
        {
            return db.Cinemas.FirstOrDefault(r => r.CinemaId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Cinema item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
