using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate.Maps
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap() {
            Table("Orders");
            LazyLoad();
            Id(o => o.OrderId).Column("OrderID");

            Map(o => o.CustomerId).Column("CustomerID");
            Map(o => o.EmployeeId).Column("EmployeeId");
            Map(o => o.OrderDate).Column("OrderDate");
            Map(o => o.RequiredDate).Column("RequiredDate");
            Map(o => o.ShippedDate).Column("ShippedDate");
            Map(o => o.ShipVia).Column("ShipVia");
            Map(o => o.Freight).Column("Freight");
            Map(o => o.ShipName).Column("ShipName");
            Map(o => o.ShipAddress).Column("ShipAddress");
            Map(o => o.ShipCity).Column("ShipCity");
            Map(o => o.ShipRegion).Column("ShipRegion");
            Map(o => o.ShipPostalCode).Column("ShipPostalCode");
            Map(o => o.ShipCountry).Column("ShipCountry");
        }
    }
}
