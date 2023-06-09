using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete.NHibernate.Helper;
using TestProject.DataAccess.ORM;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate
{
    public class NHCategoryDal : NHibarnateRepository<Category>, ICategoryDal
    {
        
        public NHCategoryDal(SqlNhibarnateHelper sqlNhibarnateHelper) : base(sqlNhibarnateHelper)
        {
            
        }
        
    }
}
