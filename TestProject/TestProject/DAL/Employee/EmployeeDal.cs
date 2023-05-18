using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.ViewModels;

namespace TestProject.DAL.Employee
{
    internal class EmployeeDal : IEmployeeDal
    {
        public void AddAsync(Models.Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<EmployeeViewModel>> BindingList(Expression<Func<Models.Employee, bool>> filter = null)
        {
            var employees = await GetAllAsync(filter);
            using (NorthwindContext context = new NorthwindContext())
            {
                var columns = employees.Select(x => new EmployeeViewModel
                {
                    EmployeeId = x.EmployeeId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Title = x.Title,
                    TitleOfCourtesy = x.TitleOfCourtesy,
                    BirthDate = x.BirthDate,
                    HireDate = x.HireDate,
                    Address = x.Address,
                    City = x.City,
                    Region = x.Region,
                    PostalCode = x.PostalCode,
                    Country = x.Country,
                    HomePhone = x.HomePhone,
                    Photo = x.Photo,
                    Extension = x.Extension,
                    Notes = x.Notes,
                    
                })
                    .OrderBy(x => x.EmployeeId)
                    .ToList();

                return columns;
            }
        }

        public void DeleteAsync(Models.Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Models.Employee>> GetAllAsync(Expression<Func<Models.Employee, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter != null ? await context.Employees.Where(filter).ToListAsync() : await context.Employees.ToListAsync();
            }
        }

        public async Task<Models.Employee> GetAsync(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return await context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            }
        }

        public async Task<List<Models.Region>> GetRegions(Expression<Func<Models.Region, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter != null ? await context.Regions.Where(filter).ToListAsync() : await context.Regions.ToListAsync();
            }
        }

        public async Task<List<Territory>> GetTerritories(Expression<Func<Territory, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter != null ? await context.Territories.Where(filter).ToListAsync() : await context.Territories.ToListAsync();
            }
        }

        public async void UpdateAsync(Models.Employee entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
