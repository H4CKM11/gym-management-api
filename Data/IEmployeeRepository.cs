using gym_management_api.Model;

namespace gym_management_api.Data
{
    public interface IEmployeeRepository
    {
        Task<ServiceResponse<int>> newEmployee(Employee employee, string password, string email, DateTime dob, string employeeType);

    }
}