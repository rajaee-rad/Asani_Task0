using System;
using System.ComponentModel.DataAnnotations;

namespace Asani_Task0.Models
{
    public class Estate
    {
        public int Id { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public float Area { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Address { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int UserIdCreator { get; set; }
        public int UserIdModifer{get;set;}
        public string Log { get; set; }
        public DateTime Timestamp { get; set; }
    }
}