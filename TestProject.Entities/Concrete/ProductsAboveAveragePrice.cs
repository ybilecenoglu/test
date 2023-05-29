using System;
using System.Collections.Generic;

namespace TestProject.Entities.Concrete
{

    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }
    }
}