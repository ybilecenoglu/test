using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Business
{
    public class ReturnException
    {
        public void returnExc(Action action) {
			try
			{
				action.Invoke();
			}
			catch (Exception exception)
			{
				System.Windows.Forms.MessageBox.Show(exception.Message);

			}
        }
    }
}
