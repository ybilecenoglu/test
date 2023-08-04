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
        //Entitiy freamwork context benzeri kullanıcı hangi veritabanıyla geldiğini anlamak için aldığımız sesion değişkeni
        private static ISessionFactory _sessionFactory;

        //Dipendency Injection yönetmi ile SessionFactory aldık.
        public virtual ISessionFactory SessionFactory { get { return _sessionFactory ?? (_sessionFactory = InitializeFactory()); } }

        //Implement edilecek yerlerde hangi veritabanına gideleceği belli olmadığı için ezilebilir hale getirdik.
        protected abstract ISessionFactory InitializeFactory();

        //Gelen session açmak için kullandığımız method
        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        //Standart dispose işlemi using kullanmak için implement edildi
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
