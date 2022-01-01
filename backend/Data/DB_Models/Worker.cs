using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DB_Models
{
    public class Worker : Entity //Name and ID from Entity
    {
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Supervisor { get; set; } //not sure if string just yet
        [NotMapped]
        public Department Department { get; set; }
    }

    public struct Department {
        int name;
        int abbreviation;
    }
}
