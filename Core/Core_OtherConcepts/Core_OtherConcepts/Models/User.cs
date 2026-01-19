using System.ComponentModel.DataAnnotations;

namespace Core_OtherConcepts.Models
{
    public class User
    {
        [Required(ErrorMessage ="Name is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage ="Email needed")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string? Email { get; set; }    

    }
}
