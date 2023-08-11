namespace EmployerRegister.Models
{
    public class UpdateEmployeeViewModel
    {
        public Guid Id { get; set; } //unique
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Department { get; set; }
    }
}
