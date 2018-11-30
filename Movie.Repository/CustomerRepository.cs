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
    public class CustomerRepository:ICustomerRepository
    {
        private MovieContext db;
        public CustomerRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Add(Customer item)
        {
            db.Customers.Add(item);
        }

        public void Delete(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer != null)
            {
                db.Customers.Remove(customer);
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

        public ICollection<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public Customer GetObject(object obj)
        {
            return db.Customers.FirstOrDefault(r => r.CustomerId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Customer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public int Login(string email, string passWord)
        {
            var result = db.Customers.SingleOrDefault(a => a.Email == email);
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public Customer GetCustomerLogin(string email)
        {
            return db.Customers.FirstOrDefault(r => r.Email == email);
        }
    }
}
