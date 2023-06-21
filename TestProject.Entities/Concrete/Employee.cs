using System;
using System.Collections.Generic;
using System.ComponentModel;
using TestProject.Entities.Abstract;

namespace TestProject.Entities.Concrete
{

    public partial class Employee : IEntity
    {
        public virtual int EmployeeId { get; set; }

        public virtual string LastName { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string Title { get; set; }

        public virtual string TitleOfCourtesy { get; set; }

        public virtual DateTime? BirthDate { get; set; }

        public virtual DateTime? HireDate { get; set; }

        public virtual string Address { get; set; }

        public virtual string City { get; set; }

        public virtual string Region { get; set; }

        public virtual string PostalCode { get; set; }

        public virtual string Country { get; set; }

        public virtual string HomePhone { get; set; }

        public virtual string Extension { get; set; }

        public virtual byte[] Photo { get; set; }

        public virtual string Notes { get; set; }
        [Browsable(false)]
        public virtual int? ReportsTo { get; set; }
        [Browsable(false)]
        public virtual string PhotoPath { get; set; }
        [Browsable(false)]
        public virtual ICollection<Employee> InverseReportsToNavigation { get; set; } = new List<Employee>();
        [Browsable(false)]
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        [Browsable(false)]
        public virtual Employee ReportsToNavigation { get; set; }
        [Browsable(false)]
        public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
    }
}