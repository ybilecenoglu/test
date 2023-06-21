using PagedList;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Business.Utilities
{
    public interface IPagedListService
    {
        Task<IPagedList<TEntity>> GetPagedList<TEntity>(List<TEntity> entity,int pageNumber = 1, int pageSize = 10);
    }
}
