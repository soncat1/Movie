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
    public class RoomTypeService
    {
        private readonly RoomTypeRepository repository;
        public RoomTypeService()
        {
            repository = new RoomTypeRepository(new MovieContext());
        }
        public ICollection<RoomType> GetAll()
        {
            return repository.GetAll();
        }
        public RoomType GetRoomType(int roomTypeId)
        {
            return repository.GetObject(roomTypeId);
        }
        public void Add(RoomType roomType)
        {
            repository.Add(roomType);
            repository.Save();
        }
        public void Update(RoomType roomType)
        {
            repository.Update(roomType);
            repository.Save();
        }
        public void Delete(int roomTypeId)
        {
            repository.Delete(roomTypeId);
            repository.Save();
        }
    }
}
