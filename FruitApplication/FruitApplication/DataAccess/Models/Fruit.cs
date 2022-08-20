using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitApplication.Models
{
    public class Fruit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Required {0} field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required {0} field")]
        //[MinLength(25, ErrorMessage = "This {0} field need to have minimun {1} caracters.")]
        public string Description { get; set; }

        public int FruitTypeId { get; set; }

        [ForeignKey("FruitTypeId")]
        public FruitType Type { get; set; } 

        public Fruit()
        {
        }
        public Fruit(int id, string name, string description, FruitType type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }
    }
}
