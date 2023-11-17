using System.ComponentModel.DataAnnotations;

namespace real_estate.Models
{
    public class Agreement
    {
        [Key]
        public int agreement_id { get; set; }
        [Required]
        public int apartment_id { get; set; }
        [Required]
        public int client_id { get; set; }
        [Required]
        public int admin_id { get; set; }
        [Required]
        [StringLength(10)]
        public string ag_type { get; set; }
        public DateTime duration { get; set;}
        [Required]
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public decimal payment {  get; set; }
    }
}
