using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Business.Utilities
{
    public class ExceptionHandlerManager : IExceptionHandlerService
    {
        public  void ReturnException(Action action)
        {
			try
			{
				action.Invoke();
			}
			catch (Exception)
			{
				throw new Exception("Hata oluştu");
			}
        }
    }
}
