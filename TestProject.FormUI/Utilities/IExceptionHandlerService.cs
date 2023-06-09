using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete;

namespace TestProject.FormUI.Utilities
{
    public interface IExceptionHandlerService
    {
        Task ReturnException(Func<Task> action);
    }
}
