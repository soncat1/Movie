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
    public class DepartmentRepository
    {
        private MovieContext db;
        public DepartmentRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Add(Department item)
        {
            db.Departments.Add(item);
        }

        public void Delete(int id)
        {
            var department = db.Departments.Find(id);
            if (department != null)
            {
                db.Departments.Remove(department);
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

        public ICollection<Department> GetAll()
        {
            return db.Departments.ToList();
        }

        public Department GetObject(object obj)
        {
            return db.Departments.FirstOrDefault(r => r.DepartmentId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Department item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
