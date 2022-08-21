using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitApplication
{
    public class FruitDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Required {0} field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required {0} field")]
        //[MinLength(25, ErrorMessage = "This {0} field need to have minimun {1} caracters.")]
        public string Description { get; set; }

        [ForeignKey("Type")]
        public int FruitTypeId { get; set; }

        public virtual FruitTypeDTO Type { get; set; }
    }
}
