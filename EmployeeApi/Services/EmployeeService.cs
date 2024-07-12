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

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            else
            {
                return await _repository.Create(employee);
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _repository.GetById(id);
        }
        public void DeleteEmployee(int Id)
        {
            if (Id != 0)
            {
                var obj = _repository.GetAll().Where(x => x.Id == Id).FirstOrDefault();
                _repository.Delete(obj);
            }
        }
        public void UpdateEmployee(Employee employee)
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
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _repository.GetAll().ToList();
        }
    }
}
