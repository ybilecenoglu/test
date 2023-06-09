using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete;

namespace TestProject.Business.Utilities
{
    public interface IExceptionHandlerService
    {
        Task<Result> ReturnException(Func<Task> action);
    }
}
