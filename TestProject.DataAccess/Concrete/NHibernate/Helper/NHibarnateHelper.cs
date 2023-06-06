using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.DataAccess.Concrete.NHibernate.Helper
{
    public abstract class NHibarnateHelper : IDisposable
    {
        //ORM session değişkeni
        private ISessionFactory _sessionFactory;

        //Dipendency Injection yönetmi ile _sessionFactory aldık.
        public virtual ISessionFactory SessionFactory { get { return _sessionFactory ?? (_sessionFactory = InitializeFactory()); } }

        //Implement edilecek yerlerde hangi veritabanına gideleceği belli olmadığı için ezilebilir hale getirdik.
        protected abstract ISessionFactory InitializeFactory();

        //Gelen session açmak için kullandığımız method
        public virtual ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
