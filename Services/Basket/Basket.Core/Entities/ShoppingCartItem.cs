﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entities
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageFile { get; set; }

    }
}
