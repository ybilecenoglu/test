﻿using NHibernate.Transform;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Business.Utilities
{
    public class PagedListManager : IPagedListService
    {
        public async Task<IPagedList<TEntity>> GetPagedList<TEntity>(List<TEntity> entity, int pageNumber = 1, int pageSize = 10)
        {
           return await Task.FromResult(entity.ToPagedList(pageNumber, pageSize));
        }
    }
}