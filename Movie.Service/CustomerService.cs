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
    public class CustomerService
    {
        private readonly CustomerRepository repository;
        public CustomerService()
        {
            repository = new CustomerRepository(new MovieContext());
        }
        public ICollection<Customer> GetAll()
        {
            return repository.GetAll();
        }
        public Customer GetCustomer(int customerId)
        {
            return repository.GetObject(customerId);
        }
        public void Add(Customer customer)
        {
            repository.Add(customer);
            repository.Save();
        }
        public void Update(Customer customer)
        {
            repository.Update(customer);
            repository.Save();
        }
        public void Delete(int customerId)
        {
            repository.Delete(customerId);
            repository.Save();
        }
    }
}
