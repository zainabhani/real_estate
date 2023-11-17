using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace real_estate.Models
{
    public class Apartments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int apartment_id { get; set; }
        [Required]
        public int property_Id { get; set; }
        [Required]
        public int apartment_nu_room {  get; set; }
        [Required]
        [StringLength(5)]
        public string apartment_state { get; set; }
        [Required]
        public decimal apartment_price { get; set; }

    }
}
