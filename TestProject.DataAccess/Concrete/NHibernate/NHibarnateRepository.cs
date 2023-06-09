using Microsoft.EntityFrameworkCore;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.Business.Utilities;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete.NHibernate.Helper;
using TestProject.Entities.Abstract;

namespace TestProject.DataAccess.Concrete.NHibernate
{
    public class NHibarnateRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private NHibarnateHelper _nHibarneteHelper;
        private IExceptionHandlerService _exceptionHandlerService;
        
        //NHibarnete Injection
        public NHibarnateRepository(NHibarnateHelper nHibarnateHelper)
        {
            _nHibarneteHelper = nHibarnateHelper;
            _exceptionHandlerService = new ExceptionHandlerManager();
        }

        public async Task<Result> AddAsync(TEntity entity)
        {
            var result = new Result { Success = false };

            result = await _exceptionHandlerService.ReturnException(async () =>
            {
                using (var session = _nHibarneteHelper.OpenSession())
                {
                    await session.SaveAsync(entity);
                }
            });

            return result;
        }

        public async Task<Result> DeleteAsync(TEntity entity)
        {
            var result = new Result { Success = false };
            result = await _exceptionHandlerService.ReturnException(async () =>
            {
                using (var session = _nHibarneteHelper.OpenSession())
                {
                    await session.DeleteAsync(entity);
                    await session.FlushAsync();//Delete operasonu yapildiktan sonra değişiklikleri veritabanına yansıması için flus method çağrıldı
                }
            });

            return result;
        }

        public async Task<Result<List<TEntity>>> GetAllAsync(Expression<System.Func<TEntity, bool>> filter = null)
        {
            var result = new Result<List<TEntity>> { Success = false };
            var exception_result = await _exceptionHandlerService.ReturnException(async () =>
            {
                using (var session = _nHibarneteHelper.OpenSession())
                {
                    result.Data = filter == null ? await Task.FromResult(session.Query<TEntity>().ToList()) : await Task.FromResult(session.Query<TEntity>().Where(filter).ToList());
                }

            });

            if (exception_result.Success == true)
                result.Success = true;
            return result;
           
        }

        public async Task<Result<TEntity>> GetAsync(Expression<System.Func<TEntity, bool>> filter)
        {
            var result = new Result<TEntity> { Success = false };
            var exception_result = await _exceptionHandlerService.ReturnException(async () =>
            {
                using (var session = _nHibarneteHelper.OpenSession())
                {
                    result.Data = await Task.FromResult(session.Query<TEntity>().SingleOrDefault(filter));
                }
            });
            if (exception_result.Success == true)
                result.Success = true;
            
            return result;
        }

        public async Task<Result> UpdateAsync(TEntity entity)
        {
            var result = new Result { Success = false };
            result = await _exceptionHandlerService.ReturnException(async () =>
            {
                using (var session = _nHibarneteHelper.OpenSession())
                {
                    await session.UpdateAsync(entity);
                    await session.FlushAsync(); //Update operasonu yapildiktan sonra değişiklikleri veritabanına yansıması için flus method çağrıldı
                }
            });
            return result;
        }
    }
}
