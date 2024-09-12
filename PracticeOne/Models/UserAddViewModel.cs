using System.ComponentModel.DataAnnotations;

namespace PracticeOne.Models
{
    public class UserAddViewModel
    {
        [Required(ErrorMessage = "Name field cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "SurName field cannot be empty")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "BirthDay field cannot be empty")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Email field cannot be empty")]
        public string Email { get; set; }
    }
}
