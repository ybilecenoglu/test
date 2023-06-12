using System;
using System.Collections.Generic;
using System.ComponentModel;
using TestProject.Entities.Abstract;

namespace TestProject.Entities.Concrete
{

    public partial class Order : IEntity
    {
        public virtual int OrderId { get; set; }

        public virtual string CustomerId { get; set; }

        public virtual int? EmployeeId { get; set; }

        public virtual DateTime? OrderDate { get; set; }

        public virtual DateTime? RequiredDate { get; set; }

        public virtual DateTime? ShippedDate { get; set; }

        public virtual int? ShipVia { get; set; }

        public virtual decimal? Freight { get; set; }

        public virtual string ShipName { get; set; }

        public virtual string ShipAddress { get; set; }

        public virtual string ShipCity { get; set; }

        public virtual string ShipRegion { get; set; }

        public virtual string ShipPostalCode { get; set; }

        public virtual string ShipCountry { get; set; }

        [Browsable(false)]
        public virtual Customer Customer { get; set; }

        [Browsable(false)]
        public virtual Employee Employee { get; set; }

        [Browsable(false)]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        [Browsable(false)]
        public virtual Shipper ShipViaNavigation { get; set; }
    }
}