
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace portfolio.Models
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string TagDescription { get; set; }
        [Required]
        public string FullDescription { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public List<byte[]> Images { get; set; }
        [Required]
        public List<string> URLs { get; set; }
    }
}
