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
    public class EmployeeService
    {
        private readonly EmployeeRepository repository;
        public EmployeeService()
        {
            repository = new EmployeeRepository(new MovieContext());
        }
        public ICollection<Employee> GetAll()
        {
            return repository.GetAll();
        }
        public Employee GetEmployee(int employeeId)
        {
            return repository.GetObject(employeeId);
        }
        public void Add(Employee employee)
        {
            repository.Add(employee);
            repository.Save();
        }
        public void Update(Employee employee)
        {
            repository.Update(employee);
            repository.Save();
        }
        public void Delete(int employeeId)
        {
            repository.Delete(employeeId);
            repository.Save();
        }
    }
}
