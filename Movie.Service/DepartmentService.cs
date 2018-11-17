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
    public class DepartmentService
    {
        private readonly DepartmentRepository repository;
        public DepartmentService()
        {
            repository = new DepartmentRepository(new MovieContext());
        }
        public ICollection<Department> GetAll()
        {
            return repository.GetAll();
        }
        public Department GetDepartment(int departmentId)
        {
            return repository.GetObject(departmentId);
        }
        public void Add(Department department)
        {
            repository.Add(department);
            repository.Save();
        }
        public void Update(Department department)
        {
            repository.Update(department);
            repository.Save();
        }
        public void Delete(int departmentId)
        {
            repository.Delete(departmentId);
            repository.Save();
        }
    }
}
