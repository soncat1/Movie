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
    public class CategoryService
    {
        private readonly CategoryRepository repository;
        public CategoryService()
        {
            repository = new CategoryRepository(new MovieContext());
        }
        public ICollection<Category> GetAll()
        {
            return repository.GetAll();
        }
        public Category GetCategory(int categoryId)
        {
            return repository.GetObject(categoryId);
        }
        public void Add(Category category)
        {
            repository.Add(category);
            repository.Save();
        }
        public void Update(Category category)
        {
            repository.Update(category);
            repository.Save();
        }
        public void Delete(int categoryId)
        {
            repository.Delete(categoryId);
            repository.Save();
        }
    }
}
