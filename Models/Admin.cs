using System.ComponentModel.DataAnnotations;

namespace real_estate.Models
{
    public class Admin
    {
        [Key]
        public int admin_id { get; set; }
        [Required]
        [StringLength(20)]
        public string username { get; set; }
        [Required]
        [StringLength(20)]
        public string password { get; set; }
        [Required]
        [StringLength(60)]
        public string name { get; set; }
        [Required]
        [StringLength(30)]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
    }
}
