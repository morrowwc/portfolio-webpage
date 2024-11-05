
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace portfolio.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public List<byte[]> Images { get; set; }

        public string? URL { get; set; }
    }
}
