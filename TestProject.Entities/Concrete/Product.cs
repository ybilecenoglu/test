using System;
using System.Collections.Generic;
using System.ComponentModel;
using TestProject.Entities.Abstract;

namespace TestProject.Entities.Concrete
{

    public partial class Product : IEntity
    {
        
        public virtual int ProductId { get; set; }

        
        public virtual string ProductName { get; set; }

        
        public virtual int? SupplierId { get; set; }

      
        public virtual int? CategoryId { get; set; }

      
        public virtual string QuantityPerUnit { get; set; }

    
        public virtual decimal? UnitPrice { get; set; }

      
        public virtual short? UnitsInStock { get; set; }

      
        public virtual short? UnitsOnOrder { get; set; }

       
        public virtual short? ReorderLevel { get; set; }

       
        public virtual bool Discontinued { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual Supplier Supplier { get; set; }
    }
}