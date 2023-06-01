using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.Entities.Abstract;

namespace TestProject.DataAccess.Concrete.EF
{
    public class EFRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> 
        where TEntity : class, IEntity, new() //Generic Kısıtı: Nesne olacak, IEntity tip olacak ve newlenecek
        where TContext : DbContext, new()
    {
        
        public async Task<Result> AddAsync(TEntity entity)
        {
            var result = new Result { Success = false };
            try
            {
                using (TContext context = new TContext())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    await context.SaveChangesAsync();
                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;

                return result;
            }
        }

        public async Task<Result> DeleteAsync(TEntity entity)
        {
            var result = new Result { Success = false };
            try
            {
                using (TContext context = new TContext())
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                    result.Success = true;
                    result.Message = "Success";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                return result;
            }

        }

        public async Task<Result<List<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            Result<List<TEntity>> result = new Result<List<TEntity>> { Success = false };
            try
            {
                using (TContext context = new TContext())
                {
                    result.Data = filter != null ?
                         await context.Set<TEntity>().Where(filter).ToListAsync() :
                         await context.Set<TEntity>().ToListAsync();
                    result.Success = true;
                    result.Message = "Success";
                    return result;
                    
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<Result<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            Result<TEntity> result = new Result<TEntity> { Success = false };
            try
            {
                using (TContext context = new TContext())
                {
                    result.Data =  await context.Set<TEntity>().FirstOrDefaultAsync(filter);
                    result.Success = true;
                    result.Message = "Başarılı";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                return result;
            }
            
        }

        public async Task<Result> UpdateAsync(TEntity entity)
        {
            var result = new Result<TEntity>() { Success = false };
            try
            {
                using (TContext context = new TContext())
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    result.Success = true;
                    result.Message = "Success";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                return result;
            }
        }
    }
}
