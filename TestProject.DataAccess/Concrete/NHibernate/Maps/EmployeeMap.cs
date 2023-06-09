using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate.Maps
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("Employees");
            LazyLoad();
            Id(e => e.EmployeeId).Column("EmployeeID");

            Map(e => e.LastName).Column("LastName");
            Map(e => e.FirstName).Column("FirstName");
            Map(e => e.Title).Column("Title");
            Map(e => e.Address).Column("Address");
            Map(e => e.TitleOfCourtesy).Column("TitleOfCourtesy");
            Map(e => e.Notes).Column("Notes");
            Map(e => e.BirthDate).Column("BirthDate");
            Map(e => e.HireDate).Column("HireDate");
            Map(e => e.City).Column("City");
            Map(e => e.Region).Column("Region");
            Map(e => e.PostalCode).Column("PostalCode");
            Map(e => e.Country).Column("Country");
            Map(e => e.HomePhone).Column("HomePhone");
            Map(e => e.Extension).Column("Extension");
            Map(e => e.Photo).Column("Photo").Length(int.MaxValue);
            Map(e => e.ReportsTo).Column("ReportsTo");
            Map(e => e.PhotoPath).Column("PhotoPath");

        }
    }
}
