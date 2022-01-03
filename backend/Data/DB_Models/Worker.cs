﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.DB_Models
{
    public class Worker : Entity //Name and ID from Entity
    {
        public string Assignment { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Supervisor { get; set; } //not sure if string just yet
        public long DepartmentId { get; set; }
        [JsonIgnore]
        public virtual Department Department { get; set; }
    }
}
