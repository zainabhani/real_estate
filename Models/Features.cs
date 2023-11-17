using System.ComponentModel.DataAnnotations;

namespace real_estate.Models
{
    public class Features
    {
        [Key]
        public int feature_id {  get; set; }
        [Required]
        public int property_Id {  get; set; }
        public string feature_descripition { get; set; }
    }
}
