using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
