using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete;

namespace TestProject.Business.Utilities
{
    public class ExceptionHandlerManager
    {
        private static ExceptionHandlerManager instance;

        public static ExceptionHandlerManager CreateInstance()
        {
            return instance ?? (instance = new ExceptionHandlerManager());
        }

        public async Task<Result> ReturnException(Func<Task> action)
        {
            var result = new Result { Success = false };
			try
			{
                await action();
                result.Success = true;
                result.Message = "Success";

                return result;
			}
			catch (Exception ex)
			{
                result.Message = ex.Message;

                return result;
            }
        }
    }
}
