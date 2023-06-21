using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete.NHibernate.Helper;
using TestProject.DataAccess.ORM;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate
{
    public class NHEmployeeDal : NHibarnateRepository<Employee>, IEmployeeDal
    {
        public NHEmployeeDal(SqlNhibarnateHelper sqlNhibarnateHelper) : base(sqlNhibarnateHelper)
        {
        }
    }
}
