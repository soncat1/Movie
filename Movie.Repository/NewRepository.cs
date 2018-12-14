using Movie.DAL;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Movie.Repository
{
    public class NewRepository : INewRepository
    {
        private MovieContext db;
        public NewRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Add(New item)
        {
            db.News.Add(item);
        }

        public void Delete(int id)
        {
            New roomType = db.News.Find(id);
            if (roomType != null)
            {
                db.News.Remove(roomType);
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
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public ICollection<New> GetAll()
        {
            return db.News.ToList();
        }

        public New GetObject(object obj)
        {
            return db.News.FirstOrDefault(r => r.NewId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(New item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
