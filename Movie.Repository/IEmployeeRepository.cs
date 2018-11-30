using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Repository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        int Login(string userName, string passWord);
        Employee GetEmployeeLogin(string userName);
    }
}
