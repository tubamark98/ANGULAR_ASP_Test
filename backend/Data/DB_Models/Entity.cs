using Data.DB_Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DB_Models
{
    public class Entity: IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [MaxLength(254)]
        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
