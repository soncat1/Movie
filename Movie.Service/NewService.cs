using Movie.DAL;
using Movie.Models;
using Movie.Repository;
using System.Collections.Generic;

namespace Movie.Service
{
    public class NewService
    {
        private readonly NewRepository repository;
        public NewService()
        {
            repository = new NewRepository(new MovieContext());
        }
        public ICollection<New> GetAll()
        {
            return repository.GetAll();
        }
    }
}
