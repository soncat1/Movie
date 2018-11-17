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
    public class FilmService
    {
        private readonly FilmRepository repository;
        public FilmService()
        {
            repository = new FilmRepository(new MovieContext());
        }
        public ICollection<Film> GetAll()
        {
            return repository.GetAll();
        }
        public Film GetFilm(int filmId)
        {
            return repository.GetObject(filmId);
        }
        public void Add(Film film)
        {
            repository.Add(film);
            repository.Save();
        }
        public void Update(Film film)
        {
            repository.Update(film);
            repository.Save();
        }
        public void Delete(int filmId)
        {
            repository.Delete(filmId);
            repository.Save();
        }
    }
}
