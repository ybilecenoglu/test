using System;
using System.Collections.Generic;
using TestProject.Entities.Abstract;

namespace TestProject.Entities.Concrete
{
    public partial class Category : IEntity
    {
        public virtual int CategoryId { get; set; }

        public virtual string CategoryName { get; set; }

        public virtual string Description { get; set; }

        public virtual byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}