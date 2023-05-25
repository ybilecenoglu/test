using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;
using TestProject.DataAccess.ViewModels;
using TestProject.DataAccess.Abstract;

namespace TestProject.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
       //
    }
}
