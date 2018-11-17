using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Models;
using System.Data.Entity;
using Movie.DAL;

namespace Movie.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private MovieContext db;
        public CategoryRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Add(Category item)
        {
            db.Categories.Add(item);
        }

        public void Delete(int id)
        {
            var category = db.Categories.Find(id);
            if(category!=null)
            {
                db.Categories.Remove(category);
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
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public ICollection<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category GetObject(object obj)
        {
            return db.Categories.FirstOrDefault(r => r.CategoryId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Category item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
