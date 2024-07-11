using DataService.Models;
using DataService.Repositories;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        public readonly IRepository<Employee> _repository;
        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        //Create Method
        public async Task<Employee> AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    throw new ArgumentNullException(nameof(employee));
                }
                else
                {
                    return await _repository.Create(employee);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                    return await _repository.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public  void DeleteEmployee(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    var obj = _repository.GetAll().Where(x => x.Id == Id).FirstOrDefault();
                    _repository.Delete(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                if (employee.Id != 0)
                {
                    var obj = _repository.GetAll().Where(x => x.Id == employee.Id).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.FirstName = employee.FirstName;
                        obj.LastName = employee.LastName;
                        obj.DOB = employee.DOB;
                        _repository.Update(obj);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return _repository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
