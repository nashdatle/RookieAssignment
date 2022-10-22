using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment4_3.Models
{
    public class MembersCreateModel
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
    }
}