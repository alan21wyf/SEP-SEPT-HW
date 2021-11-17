using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CabTypeUpdateRequestModel
    {
        public string OldCabTypeName { get; set; }
        public string NewCabTypeName { get; set; }
    }
}
