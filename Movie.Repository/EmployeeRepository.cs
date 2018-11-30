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
    public class EmployeeRepository : IEmployeeRepository
    {
        private MovieContext db;
        public EmployeeRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Add(Employee item)
        {
            db.Employees.Add(item);
        }

        public void Delete(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
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

        public ICollection<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public Employee GetObject(object obj)
        {
            return db.Employees.FirstOrDefault(r => r.EmployeeId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Employee item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public int Login(string userName, string passWord)
        {
            var result = db.Employees.SingleOrDefault(a => a.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public Employee GetEmployeeLogin(string userName)
        {
            return db.Employees.FirstOrDefault(r => r.UserName == userName);
        }
    }
}
