using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.EF
{
    public class EFEmployeeDal : EFRepositoryBase<Employee, NorthwindContext>, IEmployeeDal
    {
        public async Task<Result<List<Region>>> GetAllRegion(Expression<Func<Region, bool>> filter = null)
        {
            Result<List<Region>> regions = new Result<List<Region>> { Success = false };
            try
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    regions.Data = filter != null ? await context.Regions.Where(filter).ToListAsync() : await context.Regions.ToListAsync();
                    regions.Success = true;
                    regions.Message = "Success";

                    return regions;
                }
            }
            catch (Exception ex)
            {
                regions.Success = false;
                regions.Message = ex.Message;

                return regions;
            }
        }

        public async Task<Result<List<Territory>>> GetAllTerritories(Expression<Func<Territory, bool>> filter = null)
        {
            var result = new Result<List<Territory>> { Success = false };
            try
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    result.Data = filter != null ? await context.Territories.Where(filter).ToListAsync() : await context.Territories.ToListAsync();
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
