using System.ComponentModel.DataAnnotations;
using PortfolioCMS.Business.Models.Projects.Contracts;

namespace PortfolioCMS.Business.Models.Projects
{
    public class Image : IImage
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Path { get; set; }
    }
}
