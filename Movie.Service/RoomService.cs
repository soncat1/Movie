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
    public class RoomService
    {
        private readonly RoomRepository repository;
        public RoomService()
        {
            repository = new RoomRepository(new MovieContext());
        }
        public ICollection<Room> GetAll()
        {
            return repository.GetAll();
        }
        public Room GetRoom(int roomId)
        {
            return repository.GetObject(roomId);
        }
        public void Add(Room room)
        {
            repository.Add(room);
            repository.Save();
        }
        public void Update(Room room)
        {
            repository.Update(room);
            repository.Save();
        }
        public void Delete(int roomId)
        {
            repository.Delete(roomId);
            repository.Save();
        }
    }
}
