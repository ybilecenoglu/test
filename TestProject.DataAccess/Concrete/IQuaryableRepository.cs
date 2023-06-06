using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Abstract;

namespace TestProject.DataAccess.Concrete
{
    //IQuaryable arayüzü
    public interface IQuaryableRepository<T> where T: class,IEntity, new ()
    {
        IQueryable<T> Table { get; }
    }
}
