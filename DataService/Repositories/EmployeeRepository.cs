using Microsoft.EntityFrameworkCore;
using DataService.Models;
using System.Linq;
using DataService.Data;
using Microsoft.Extensions.Logging;

namespace DataService.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly DataBaseContext _dbContext;
        private readonly ILogger _logger;
        public EmployeeRepository(DataBaseContext dbContext, ILogger<Employee> logger)
        {
            _dbContext = dbContext;
            _logger = _logger;
        }

        public async Task<Employee> Create(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    var obj = _dbContext.Add<Employee>(employee);
                    await _dbContext.SaveChangesAsync();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async void Delete(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    var obj = _dbContext.Remove(employee);
                    if (obj != null)
                    {
                       await  _dbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                var obj =  _dbContext.Employees.ToList();
                if (obj != null) return obj;
                else return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<Employee> GetById(int Id)
        {
            try
            {
                if (Id != null)
                {
                    var Obj = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == Id);
                    if (Obj != null) return Obj;
                    else return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { _logger.LogError(ex.ToString()); throw; }
        }
        public async void Update(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    var obj = _dbContext.Update(employee);
                    if (obj != null) await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex) { _logger.LogError(ex.ToString()); throw; }
        }
    }
}
