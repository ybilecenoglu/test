using NHibernate.Transform;
using PagedList;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Utilities
{
    public class PagedListManager
    {
        private static PagedListManager instance;
        public async Task<IPagedList<TEntity>> GetPagedList<TEntity>(List<TEntity> entity, int pageNumber = 1, int pageSize = 10)
        {
           return await Task.FromResult(entity.AsQueryable().ToPagedList(pageNumber, pageSize));
        }

        public static PagedListManager CreateInstance()
        {
           return instance ?? (instance = new PagedListManager());
        }
    }
}
