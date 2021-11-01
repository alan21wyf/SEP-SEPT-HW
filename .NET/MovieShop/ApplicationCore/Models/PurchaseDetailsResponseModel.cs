﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PurchaseDetailsResponseModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public DateTime PurchaseTime { get; set; }
        public decimal Price { get; set; }
        public Guid PurchaseNumber { get; set; }
    }
}
