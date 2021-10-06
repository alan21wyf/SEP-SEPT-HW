using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CompanyApp.Data.Model
{
    public class Customers
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
