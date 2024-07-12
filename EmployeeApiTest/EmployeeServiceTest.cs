using DataService.Models;
using EmployeeApi.Services;
using DataService.Repositories;

namespace EmployeeApiTest
{
    public class EmployeeServiceTest
    {
        private Mock<IRepository<Employee>> _mockDbService;
        private EmployeeService _uut;
        
        public EmployeeServiceTest()
        {
            _mockDbService = new Mock<IRepository<Employee>>();
        }
        private void CreateService()
        {
            _uut = new EmployeeService(_mockDbService.Object);
        }
        [Fact]
        public async Task ShouldThrowWhenEmployeeIsNull()
        {

            // GIVEN
            CreateService();

            // WHEN
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(async () => await _uut.AddEmployee(null));

            // THEN
            Assert.Contains("Value cannot be null.", ex.Message);
        }

        [Fact]
        public async Task ShouldReturnSuccessForAddEmployee()
        {

            // GIVEN
            var employee = new Employee
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                DOB = DateTime.Now
            };
            CreateService();

            // WHEN
            var result = await _uut.AddEmployee(employee);

            // THEN
            Assert.NotNull(result);
        }
    }
}