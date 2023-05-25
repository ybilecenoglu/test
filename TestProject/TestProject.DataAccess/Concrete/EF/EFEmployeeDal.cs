using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.EF
{
    public class EFEmployeeDal : EFRepositoryBase<Employee, NorthwindContext>, IEmployeeDal
    {
        
    }
}
