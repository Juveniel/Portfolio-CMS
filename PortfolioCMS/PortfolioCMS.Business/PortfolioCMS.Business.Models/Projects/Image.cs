using System.ComponentModel.DataAnnotations;

namespace PortfolioCMS.Business.Models.Projects
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Path { get; set; }
    }
}
