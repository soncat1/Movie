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
    public class CinemaService
    {
        private readonly CinemaRepository repository;
        public CinemaService()
        {
            repository = new CinemaRepository(new MovieContext());
        }
        public ICollection<Cinema> GetAll()
        {
            return repository.GetAll();
        }
        public Cinema GetCinema(int cinemaId)
        {
            return repository.GetObject(cinemaId);
        }
        public void Add(Cinema cinema)
        {
            repository.Add(cinema);
            repository.Save();
        }
        public void Update(Cinema cinema)
        {
            repository.Update(cinema);
            repository.Save();
        }
        public void Delete(int cinemaId)
        {
            repository.Delete(cinemaId);
            repository.Save();
        }
    }
}
