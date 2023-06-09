using Microsoft.EntityFrameworkCore;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete.NHibernate.Helper;
using TestProject.DataAccess.ORM;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate
{
    public class NHProductDal : NHibarnateRepository<TestProject.Entities.Concrete.Product>, IProductDal
    {
        private SqlNhibarnateHelper _sqlHelper;
        
        //Nhibarnate DI enjekte edildi.
        public NHProductDal(SqlNhibarnateHelper SqlHelper) : base(SqlHelper)
        {
            _sqlHelper = SqlHelper;
        }

        public async Task<Result<List<Category>>> GetCategories()
        {
            var result = new Result<List<Category>>();
            try
            {
                using (var session = _sqlHelper.OpenSession())
                {
                    result.Data = await Task.FromResult(session.Query<Category>().ToList());
                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Hata oluştu";

                return result;
            }
            
        }

        public async Task<Result<Category>> GetCategory(Expression<Func<Category, bool>> filter)
        {
            var result = new Result<Category> { Success = false };
            try
            {
                using (var session = _sqlHelper.OpenSession())
                {
                    result.Data = await Task.FromResult
                        (session.Query<Category>().SingleOrDefault(filter));
                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Kategori getirilirken bir hata oluştu";

                return result;
            }
        }

        public async Task<Result<Supplier>> GetSupplier(Expression<Func<Supplier, bool>> filter)
        {
            var result = new Result<Supplier> { Success = false };
            try
            {
                using (var session = _sqlHelper.OpenSession())
                {
                    result.Data = await Task.FromResult
                        (session.Query<Supplier>().SingleOrDefault(filter));
                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Kategori getirilirken bir hata oluştu";

                return result;
            }
        }

        public async Task<Result<List<Supplier>>> GetSuppliers()
        {
            var result = new Result<List<Supplier>>();
            try
            {
                using (var session = _sqlHelper.OpenSession())
                {
                    result.Data = await Task.FromResult(session.Query<Supplier>().ToList());
                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Hata oluştu";

                return result;
            }
        }
    }
}
