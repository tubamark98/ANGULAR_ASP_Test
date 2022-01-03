using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.DB_Models
{
    public class Department : Entity
    {
        public string Abreviation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Worker> AssignedWorkers { get; set; }

        public Department()
        {
            this.AssignedWorkers = new List<Worker>();
        }
    }
}
