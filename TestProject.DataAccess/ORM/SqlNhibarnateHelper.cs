using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete.NHibernate.Helper;

namespace TestProject.DataAccess.ORM
{
    public class SqlNhibarnateHelper : NHibarnateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {
            var connString = ConfigurationManager.ConnectionStrings["NorthwindContext"].ConnectionString;
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(connString))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())).BuildSessionFactory();
        }
    }
}
