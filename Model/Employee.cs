namespace gym_management_api.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string EmployeeType { get; set; } = string.Empty;
    }
}