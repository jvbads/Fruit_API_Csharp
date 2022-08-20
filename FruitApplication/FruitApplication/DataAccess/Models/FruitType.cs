
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitApplication.Models
{
    public class FruitType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int FruitTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
