using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.ORM;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate
{
    public class NHEmployeeDal : NHibarnateRepository<Employee>, IEmployeeDal
    {
        private SqlNhibarnateHelper _SqlNhibarnateHelper;
        public NHEmployeeDal(SqlNhibarnateHelper sqlNhibarnateHelper) : base(sqlNhibarnateHelper)
        {
            _SqlNhibarnateHelper = sqlNhibarnateHelper;
        }

        public async Task<Result<List<Region>>> GetAllRegion(Expression<Func<Region, bool>> filter = null)
        {
            var result = new Result<List<Region>> { Success = false };
            try
            {
                using (var session = _SqlNhibarnateHelper.OpenSession())
                {
                    result.Data = await session.Query<Region>().ToListAsync();
                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            catch (Exception)
            {
                result.Message = "Hata oluştu";
                return result;
            }
        }

        public async Task<Result<List<Territory>>> GetAllTerritories(Expression<Func<Territory, bool>> filter = null)
        {
            var result = new Result<List<Territory>> { Success = false };
            try
            {
                using (var session = _SqlNhibarnateHelper.OpenSession())
                {
                    result.Data = await session.Query<Territory>().ToListAsync();
                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            catch (Exception)
            {
                result.Message = "Hata oluştu";
                return result;
            }
        }
    }
}
