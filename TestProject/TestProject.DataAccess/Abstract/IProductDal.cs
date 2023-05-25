using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;
using TestProject.DataAccess.ViewModels;

namespace TestProject.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        
    }
}
