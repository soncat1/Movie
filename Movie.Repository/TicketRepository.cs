using Movie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.DAL;

namespace Movie.Repository
{
    public class TicketRepository:ITicketRepository
    {
        private MovieContext db;
        public TicketRepository(MovieContext db)
        {
            this.db = db;
        }

        public void Add(Ticket item)
        {
            db.Tickets.Add(item);
        }

        public void Delete(int id)
        {
            var ticket = db.Tickets.Find(id);
            if (ticket != null)
            {
                db.Tickets.Remove(ticket);
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

        public ICollection<Ticket> GetAll()
        {
            return db.Tickets.ToList();
        }

        public Ticket GetObject(object obj)
        {
            return db.Tickets.FirstOrDefault(r => r.TicketId == (int)obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Ticket item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
