using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Repository
{
    public interface IRepository<T> : IDisposable
    {
        ICollection<T> GetAll();
        T GetObject(object obj);
        void Add(T item);
        void Update(T item);
        void Delete(int id);

        void Save();
    }
}
