using System;
using System.Collections.Generic;

namespace TestProject.Entities.Concrete
{

    public partial class Territory
    {
        public virtual string TerritoryId { get; set; }

        public virtual string TerritoryDescription { get; set; }

        public virtual int RegionId { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}