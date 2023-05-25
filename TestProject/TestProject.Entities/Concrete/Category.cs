using System;
using System.Collections.Generic;
using TestProject.Entities.Abstract;

namespace TestProject.Entities.Concrete
{
    public partial class Category : IEntity
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}