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
    public class ShowtimeService
    {
        private readonly ShowtimeRepository repository;
        public ShowtimeService()
        {
            repository = new ShowtimeRepository(new MovieContext());
        }
        public ICollection<Showtime> GetAll()
        {
            return repository.GetAll();
        }
        public Showtime GetShowtime(int showtimeId)
        {
            return repository.GetObject(showtimeId);
        }
        public void Add(Showtime showtime)
        {
            repository.Add(showtime);
            repository.Save();
        }
        public void Update(Showtime showtime)
        {
            repository.Update(showtime);
            repository.Save();
        }
        public void Delete(int showtimeId)
        {
            repository.Delete(showtimeId);
            repository.Save();
        }
    }
}
