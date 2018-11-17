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
    public class FilmRepository:IFilmRepository
    {
        private MovieContext db;
        public FilmRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Add(Film item)
        {
            db.Films.Add(item);
        }

        public void Delete(int id)
        {
            var film = db.Films.Find(id);
            if (film != null)
            {
                db.Films.Remove(film);
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

        public ICollection<Film> GetAll()
        {
            return db.Films.ToList();
        }

        public Film GetObject(object obj)
        {
            return db.Films.FirstOrDefault(r => r.FilmId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Film item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
