using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.DataAccess.Abstract;
using TestProject.DataAccess.Concrete;
using TestProject.DataAccess.ViewModels;
using TestProject.Entities.Concrete;

namespace TestProject.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal) {
            _categoryDal = categoryDal;
        }
        public async Task<Result> AddCategory(Category category)
        {
            var result = await _categoryDal.AddAsync(category);
            return result;
        }
        public Task<Result> UpdateCategory(Category category)
        {
            var result = _categoryDal.UpdateAsync(category);
            return result;

        }
        public async Task<Result> DeleteCategory(Category category)
        {
            var result = await _categoryDal.DeleteAsync(category);
            return result;
        }
        public async Task<Result<List<CategoryViewModel>>> GetCategories(Expression<Func<Category, bool>> filter)
        {
            Result<List<CategoryViewModel>> result = new Result<List<CategoryViewModel>> { Success = false };
            var categoryResult = filter != null ? await _categoryDal.GetAllAsync(filter) : await _categoryDal.GetAllAsync();
            
            if (categoryResult.Success == true)
            {
                result.Data = categoryResult.Data.Select(x => new CategoryViewModel
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    Description = x.Description,
                    Picture = x.Picture

                })
                .OrderBy(x => x.CategoryId)
                .ToList();
                result.Success = true;
                result.Message = "Success";
                return result;
            }
            else
                return result;
        }
        public async Task<Result<Category>> GetCategory(Expression<Func<Category, bool>> filter)
        {
            var result = await _categoryDal.GetAsync(filter);
            return result;
        }
        //Image convert to byte method
        public Result<byte[]> ImageToByte(Image image, ImageFormat imageFormat)
        {
            var result = new Result<byte[]>() { Success = false};
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var bitMap = new Bitmap(image);
                    bitMap.Save(ms, imageFormat);
                    result.Success = true;
                    result.Message = "Success";
                    result.Data = ms.ToArray();

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message+= ex.Message;
                return result;
            }
        }
        //Byte convert to image method
        public Result<Image> ByteToImage(byte[] bytes)
        {
            var result = new Result<Image>() { Success = false };
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
                {
                    Image image = Image.FromStream(ms, true);
                    result.Success = true;
                    result.Message = "Success";
                    result.Data = image;

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
