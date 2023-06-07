using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate.Maps
{
    public class SupplierMap : ClassMap<Supplier>
    {
        public SupplierMap()
        {
            Table("Suppliers");
            LazyLoad();
            Id(x => x.SupplierId).Column("SupplierID");

            Map(x => x.CompanyName).Column("CompanyName");
            Map(x => x.ContactName).Column("ContactName");
            Map(x => x.ContactTitle).Column("ContactTitle");
            Map(x => x.Address).Column("Address");
            Map(x => x.City).Column("City");
            Map(x => x.Region).Column("Region");
            Map(x => x.PostalCode).Column("PostalCode");
            Map(x => x.Country).Column("Country");
            Map(x => x.Phone).Column("Phone");
            Map(x => x.Fax).Column("Fax");
            Map(x => x.HomePage).Column("HomePage");

        }
    }
}
