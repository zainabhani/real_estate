using System.ComponentModel.DataAnnotations;

namespace real_estate.Models
{
    public class Client
    {
        [Key]
        public int client_id { get; set; }
        [Required]
        [StringLength(20)]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [StringLength(30)]
        public string email { get; set;}
        [Required]
        [StringLength(60)]
        public string name { get; set;}
        [Required]
        public string phone { get; set; }
        [StringLength(15)]
        public string city { get; set;}

    }
}
