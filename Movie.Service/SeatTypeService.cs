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
    public class SeatTypeService
    {
        private readonly SeatTypeRepository repository;
        public SeatTypeService()
        {
            repository = new SeatTypeRepository(new MovieContext());
        }
        public ICollection<SeatType> GetAll()
        {
            return repository.GetAll();
        }
        public SeatType GetSeatType(int seatTypeId)
        {
            return repository.GetObject(seatTypeId);
        }
        public void Add(SeatType seatType)
        {
            repository.Add(seatType);
            repository.Save();
        }
        public void Update(SeatType seatType)
        {
            repository.Update(seatType);
            repository.Save();
        }
        public void Delete(int seatTypeId)
        {
            repository.Delete(seatTypeId);
            repository.Save();
        }
    }
}
