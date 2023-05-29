using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.Entities.Concrete;
using TestProject.DataAccess.ViewModels;

namespace TestProject.DataAccess.Abstract
{
    internal interface IEmployeeDal : IEntityRepository<Employee>
    {

    }
}
