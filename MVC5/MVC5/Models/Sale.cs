﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class Sale
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

    }
}