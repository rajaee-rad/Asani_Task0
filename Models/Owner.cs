using System.ComponentModel.DataAnnotations;

namespace Asani_Task0.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
    }
}