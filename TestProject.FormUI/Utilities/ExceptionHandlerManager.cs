using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Concrete;

namespace TestProject.FormUI.Utilities
{
    public class ExceptionHandlerManager : IExceptionHandlerService
    {
        public async Task ReturnException(Func<Task> action)
        {
			try
			{
                await action();
			}
			catch (Exception ex)
			{
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
