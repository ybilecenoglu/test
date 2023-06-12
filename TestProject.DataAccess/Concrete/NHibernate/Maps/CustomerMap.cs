using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate.Maps
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customers");
            LazyLoad();
            Id(c => c.CustomerId).Column("CustomerID");

            Map(c => c.CompanyName).Column("CompanyName");
            Map(c => c.ContactName).Column("ContactName");
            Map(c => c.ContactTitle).Column("ContactTitle");
            Map(c => c.Address).Column("Address");
            Map(c => c.City).Column("City");
            Map(c => c.Region).Column("Region");
            Map(c => c.PostalCode).Column("PostalCode");
            Map(c => c.Country).Column("Country");
            Map(c => c.Phone).Column("Phone");
            Map(c => c.Fax).Column("Fax");
        }
    }
}
