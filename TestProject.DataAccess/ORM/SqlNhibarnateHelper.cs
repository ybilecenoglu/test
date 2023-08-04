using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Configuration;
using System.Reflection;
using TestProject.DataAccess.Concrete.NHibernate.Helper;

namespace TestProject.DataAccess.ORM
{
    //SQL bağlantısı için kullanılan helper nesnesi
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
