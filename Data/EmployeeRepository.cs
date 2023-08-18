using gym_management_api.Model;

namespace gym_management_api.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext context;
        public EmployeeRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<ServiceResponse<int>> newEmployee(Employee employee, string password, string email, DateTime dob, string employeeType)
        {
            var response = new ServiceResponse<int>();

            employee.Email = email;
            employee.Password = password;
            employee.Birthday = dob;
            employee.EmployeeType = employeeType;

            this.context.Employees.Add(employee);
            await this.context.SaveChangesAsync();

            response.Data = employee.Id;
            response.Success = true;
            response.Message = "User Created!";

            return response;
        
        }
    }
}