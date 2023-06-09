using Microsoft.EntityFrameworkCore;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete.NHibernate.Helper;
using TestProject.Entities.Abstract;

namespace TestProject.DataAccess.Concrete.NHibernate
{
    public class NHibarnateRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private NHibarnateHelper _nHibarneteHelper;

        //NHibarnete Injection
        public NHibarnateRepository(NHibarnateHelper nHibarnateHelper)
        {
            _nHibarneteHelper = nHibarnateHelper;
        }

        public async Task<Result> AddAsync(TEntity entity)
        {
            var result = new Result { Success = false };
            try
            {
                using (var session = _nHibarneteHelper.OpenSession())
                {
                    await session.SaveAsync(entity);
                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            catch
            {
                result.Success = false;
                result.Message = "Ekleme işlemi gerçekleşirken bir hata oluştu";
                return result;
            }

        }

        public async Task<Result> DeleteAsync(TEntity entity)
        {
            var result = new Result { Success = false };
            try
            {
                using (var session = _nHibarneteHelper.OpenSession())
                {
                    await session.DeleteAsync(entity);
                    await session.FlushAsync();//Delete operasonu yapildiktan sonra değişiklikleri veritabanına yansıması için flus method çağrıldı
                    result.Success = true;
                    result.Message = "Success";
                    return result;
                }
            }
            catch (Exception)
            {

                result.Success = false;
                result.Message = "Silme işlemi gerçekleşirken bir hata oluştu";
                return result;
            }
        }

        public async Task<Result<List<TEntity>>> GetAllAsync(Expression<System.Func<TEntity, bool>> filter = null)
        {
            var result = new Result<List<TEntity>> { Success = false };
            try
            {
                using (var session = _nHibarneteHelper.OpenSession())
                {
                    result.Data = filter == null ? await Task.FromResult(session.Query<TEntity>().ToList()) : await Task.FromResult(session.Query<TEntity>().Where(filter).ToList());
                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Listeleme gerçekleşirken bir hata oluştu";

                return result;
            }
        }

        public async Task<Result<TEntity>> GetAsync(Expression<System.Func<TEntity, bool>> filter)
        {
            var result = new Result<TEntity> { Success = false };
            try
            {
                using (var session = _nHibarneteHelper.OpenSession())
                {
                    result.Data = await Task.FromResult(session.Query<TEntity>().SingleOrDefault(filter));
                    
                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Hata oluştu.";

                return result;
            }
        }

        public async Task<Result> UpdateAsync(TEntity entity)
        {
            var result = new Result { Success = false};
            try
            {
                using (var session = _nHibarneteHelper.OpenSession())
                {
                    await session.UpdateAsync(entity);
                    await session.FlushAsync(); //Update operasonu yapildiktan sonra değişiklikleri veritabanına yansıması için flus method çağrıldı
                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Güncelleme işlemi gerçekleşirken bir hata oluştu.";

                return result;
            }
        }
    }
}
