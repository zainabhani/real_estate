using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace real_estate.Models
{
    public class Houses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int houses_id { get; set; }
        [Required]
        public int property_Id { get; set; }
        [Required]
        [StringLength(5)]
        public string house_state { get; set; }
        [Required]
        public int house_nu_room {  get; set; }
        public decimal house_price { get; set; }

    }
}
