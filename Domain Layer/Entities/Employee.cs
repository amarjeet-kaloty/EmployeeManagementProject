using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementProject.Domain_Layer.Entities
{
    public class Employee : Entity
    {
        [Required(ErrorMessage = "Name is required.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public required string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? Phone { get; set; }

        public Employee() : base()
        {

        }

        public Employee(string name, string address, string email, string? phone) : base()
        {
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}
