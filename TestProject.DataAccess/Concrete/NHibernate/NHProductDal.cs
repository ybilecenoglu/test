using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete.NHibernate.Helper;
using TestProject.Entities.Concrete;

namespace TestProject.DataAccess.Concrete.NHibernate
{
    public class NHProductDal : NHibarnateRepository<Product>, IProductDal
    {
        private NHibarnateHelper _nhHelper;
        //Nhibarnate implementasyonu yapıldı.
        public NHProductDal(NHibarnateHelper nhHelper) : base(nhHelper)
        {
            _nhHelper = nhHelper;
        }

        public async Task<Result<List<Category>>> GetCategories()
        {
            var result = new Result<List<Category>>();
            try
            {
                using (var session = _nhHelper.OpenSession())
                {
                    result.Data = await session.Query<Category>().ToListAsync();
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

        public Task<Result<List<Supplier>>> GetSuppliers()
        {
            throw new NotImplementedException();
        }
    }
}
