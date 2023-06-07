using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.ViewModels
{
    public class ProductViewModel
    {
        [DisplayName("Id")]
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Supplier")]
        public string CompanyName { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }

        [DisplayName("Quantity Per Unit")]
        public string QuantityPerUnit { get; set; }

        [DisplayName("Unit Price")]
        public decimal? UnitPrice { get; set; }

        [DisplayName("Units In Stock")]
        public short? UnitsInStock { get; set; }

        [DisplayName("Units On Order")]
        public short? UnitsOnOrder { get; set; }

        [DisplayName("Reorder Level")]
        public short? ReorderLevel { get; set; }

        [DisplayName("Discontinued")]
        public bool Discontinued { get; set; }
    }
}
