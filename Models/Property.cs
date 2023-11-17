using System.ComponentModel.DataAnnotations;

namespace real_estate.Models
{
    public class Property
    {
        [Key]
        public int property_Id { get; set; }
        [Required]
        public int client_Id { get; set; }
        [Required]
        public int admin_id { get; set; }
        
        [StringLength(20)]
        public string p_type { get; set; }
        [Required]
        [StringLength(100)]
        public string location { get; set;}

    }
}
