using System;
using System.ComponentModel.DataAnnotations;

namespace Logic.DTO_Models
{
    public class TokenModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Token { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
    }
}
