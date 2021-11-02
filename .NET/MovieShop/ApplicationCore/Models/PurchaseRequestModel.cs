﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PurchaseRequestModel
    {
        public PurchaseRequestModel()
        {
            PurchaseDateTime = DateTime.Now;
            PurchaseNumber = Guid.NewGuid();
        }
        public Guid? PurchaseNumber { get; set; }
        public DateTime? PurchaseDateTime { get; set; }
        public int MovieId { get; set; }
    }
}
