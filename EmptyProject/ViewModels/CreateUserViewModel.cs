using System.ComponentModel.DataAnnotations;

namespace EmptyProject.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 4)]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(5,ErrorMessage ="Пароль повинен містити більше ніж 5 символів")]
        [MaxLength(10)]
        public string Password { get; set; }

        [Required]
        public string Password2 { get; set; }
    }


}