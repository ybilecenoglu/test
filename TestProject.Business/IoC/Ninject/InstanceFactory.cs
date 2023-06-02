using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Business.IoC.Ninject
{
    public class InstanceFactory
    {
        //Form uygulamalarında const. parametre gönderemediğimiz için bir instance sınıfı oluşturduk get methodu ile instance aldık.
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
