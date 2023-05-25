using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Abstract
{
     public interface ISupplierDal : IEntityRepository<Supplier>
    {

    }
}
