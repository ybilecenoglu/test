using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate.Maps
{
    public class TerritoriesMap : ClassMap<Territory>
    {
        public TerritoriesMap()
        {
            Table("Territories");
            LazyLoad();
            Id(t => t.TerritoryId);

            Map(t => t.TerritoryDescription).Column("TerritoryDescription");
            Map(t => t.RegionId).Column("RegionId");
        }
    }
}
