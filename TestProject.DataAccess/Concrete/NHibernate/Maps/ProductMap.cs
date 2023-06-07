using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate.Maps
{
    public class ProductMap:ClassMap<Product> //FluentNhibarnate classmap implementasyonu
    {
        public ProductMap()
        {
            Table("Products"); // Veritabanında tablo ismi
            LazyLoad();
            Id(x => x.ProductId).Column("ProductID");

            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.CategoryId).Column("CategoryID");
            Map(x => x.SupplierId).Column("SupplierID");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            Map(x => x.UnitPrice).Column("UnitPrice");
            Map(x => x.UnitsInStock).Column("UnitsInStock");
            Map(x => x.UnitsOnOrder).Column("UnitsOnOrder");
            Map(x => x.ReorderLevel).Column("ReorderLevel");
            Map(x => x.Discontinued).Column("Discontinued");


        }
    }
}
