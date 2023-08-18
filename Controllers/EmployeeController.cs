using gym_management_api.Data;
using gym_management_api.DTO.Employee;
using gym_management_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace gym_management_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeRepository EmployeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
        }

        [HttpPost("NewEmployee")]
        public async Task<ActionResult<ServiceResponse<int>>> newEmployee(EmployeeRegisterDTO employee)
        {
            var response = await this.EmployeeRepository.newEmployee(
                new Employee {Username = employee.Username}, employee.Password, employee.Email, employee.Birthday, employee.EmployeeType
            );

            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
