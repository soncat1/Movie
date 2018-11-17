using Movie.DAL;
using Movie.Models;
using Movie.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Service
{
    public class TicketService
    {
        private readonly TicketRepository repository;
        public TicketService()
        {
            repository = new TicketRepository(new MovieContext());
        }
        public ICollection<Ticket> GetAll()
        {
            return repository.GetAll();
        }
        public Ticket GetTicket(int ticketId)
        {
            return repository.GetObject(ticketId);
        }
        public void Add(Ticket ticket)
        {
            repository.Add(ticket);
            repository.Save();
        }
        public void Update(Ticket ticket)
        {
            repository.Update(ticket);
            repository.Save();
        }
        public void Delete(int ticketId)
        {
            repository.Delete(ticketId);
            repository.Save();
        }
    }
}
