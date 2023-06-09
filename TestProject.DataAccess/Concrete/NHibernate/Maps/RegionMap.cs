using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate.Maps
{
    public class RegionMap : ClassMap<Region>
    {
        public RegionMap()
        {
            Table("Region");
            LazyLoad();
            Id(r => r.RegionId);

            Map(r => r.RegionDescription).Column("RegionDescription");
        }
    }
}
