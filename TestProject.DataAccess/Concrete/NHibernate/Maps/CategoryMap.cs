using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate.Maps
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            LazyLoad();
            Id(x => x.CategoryId).Column("CategoryID");

            Map(x => x.CategoryName).Column("CategoryName");
            Map(x => x.Description).Column("Description");

            //Byte type Length çözüldü - error dehydrating property value for fluent nhibernate 
            Map(x => x.Picture).Length(int.MaxValue).Column("Picture");
        }
    }
}
