using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public ICollection<Bookings> BookingsTo { get; set; }
        public ICollection<Bookings> BookingsFrom { get; set; }

        public ICollection<BookingsHistory> BookingsHistoriesTo { get; set; }
        public ICollection<BookingsHistory> BookingsHistoriesFrom { get; set; }

    }
}
