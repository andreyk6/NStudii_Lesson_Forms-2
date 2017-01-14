using System.ComponentModel.DataAnnotations;

namespace EmptyProject.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [Display(GroupName = "G1" , Order = 2)]
        [StringLength(maximumLength: 10, MinimumLength = 4)]
        public string Login { get; set; }

        [Required]
        [Display(GroupName = "G1", Order = 1)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(GroupName = "G2", Order = 3)]
        [MinLength(5,ErrorMessage ="Пароль повинен містити більше ніж 5 символів")]
        [MaxLength(10)] 
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "Repeat your password",GroupName = "G2" , Order = 4)]
        public string Password2 { get; set; }
    }


}