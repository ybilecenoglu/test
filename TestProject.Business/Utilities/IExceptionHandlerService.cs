using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Business.Utilities
{
    public interface IExceptionHandlerService
    {
        void ReturnException(Action action);
    }
}
