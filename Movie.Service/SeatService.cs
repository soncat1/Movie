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
    public class SeatService
    {
        private readonly SeatRepository repository;
        public SeatService()
        {
            repository = new SeatRepository(new MovieContext());
        }
        public ICollection<Seat> GetAll()
        {
            return repository.GetAll();
        }
        public Seat GetSeat(int seatId)
        {
            return repository.GetObject(seatId);
        }
        public void Add(Seat seat)
        {
            repository.Add(seat);
            repository.Save();
        }
        public void Update(Seat seat)
        {
            repository.Update(seat);
            repository.Save();
        }
        public void Delete(int seatId)
        {
            repository.Delete(seatId);
            repository.Save();
        }
    }
}
