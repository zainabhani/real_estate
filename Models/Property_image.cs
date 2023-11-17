using System.ComponentModel.DataAnnotations;

namespace real_estate.Models
{
    public class Property_image
    {
        [Key]
        public int pi_id {  get; set; }
        [Required]
        public int property_Id { get; set;}
        public string? pi_image { get; set;}
    }
}
