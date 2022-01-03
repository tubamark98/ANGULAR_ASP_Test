using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Data.DB_Models.Interfaces;

namespace Data.DB_Models
{
    public class Worker : Entity
    {
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [MaxLength(254)]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [MaxLength(254)]
        public string Assignment { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [MaxLength(254)]
        public string Password { get; set; } //Very bad practise, no hashing or salt/peper implemented
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [MaxLength(254)]
        public string Supervisor { get; set; } //not sure if string just yet
        public long DepartmentId { get; set; }
        [JsonIgnore]
        public virtual Department Department { get; set; }
    }
}
