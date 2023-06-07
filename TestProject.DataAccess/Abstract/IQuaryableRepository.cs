using System.Linq;
using TestProject.Entities.Abstract;

namespace TestProject.DataAccess.Abstract
{
    //IQuaryable arayüzü
    public interface IQuaryableRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}
