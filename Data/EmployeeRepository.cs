using gym_management_api.Model;
using Microsoft.EntityFrameworkCore;

namespace gym_management_api.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext context;
        public EmployeeRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<ServiceResponse<int>> login(string username, string password)
        {
            var response = new ServiceResponse<int>();
            var user = await this.context.Employees.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));

            if(user == null)
            {
                response.Success = false;
                response.Message = "User was not found";
            }
            else
            {
                if(user.Username == username && user.Password == password)
                {
                    response.Success = true;
                    response.Message = "Login Success";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Wrong Password";
                }
            }

            return response;
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