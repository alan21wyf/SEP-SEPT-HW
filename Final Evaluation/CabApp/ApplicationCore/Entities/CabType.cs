using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class CabType
    {
        public int CabTypeId { get; set; }
        public string CabTypeName { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
        public ICollection<BookingsHistory> BookingsHistories { get; set; }
    }
}
