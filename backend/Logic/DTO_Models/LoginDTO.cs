using System.ComponentModel.DataAnnotations;

namespace Logic.DTO_Models
{
    public class LoginDTO
    {
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [MaxLength(254)]
        public string LoginName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]

        public string Password { get; set; }
    }
}
