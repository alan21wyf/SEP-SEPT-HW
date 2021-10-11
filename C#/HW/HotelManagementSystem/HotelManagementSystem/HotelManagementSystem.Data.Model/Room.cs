using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Data.Model
{
    public class Room
    {
        public int ID { get; set; }
        public int? RTCode { get; set; }
        public bool? Status { get; set; }
        public RoomType RoomType { get; set; }

    }
}
