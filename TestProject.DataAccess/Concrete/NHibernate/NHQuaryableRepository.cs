using System.Linq;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete.NHibernate.Helper;
using TestProject.Entities.Abstract;

namespace TestProject.DataAccess.Concrete.NHibernate
{
    public class NHQuaryableRepository<T> : IQuaryableRepository<T> where T : class, IEntity, new()
    {
        private NHibarnateHelper _nHibarnateHelper;
        private IQueryable<T> _entities;

        public NHQuaryableRepository(NHibarnateHelper nHibarnateHelper)
        {
              _nHibarnateHelper = nHibarnateHelper;
        }

        public IQueryable<T> Table => this.Entities;

        //Quaryable interface implementasyonu
        public virtual IQueryable<T> Entities => _entities ?? (_entities = _nHibarnateHelper.OpenSession().Query<T>());
    }
}
