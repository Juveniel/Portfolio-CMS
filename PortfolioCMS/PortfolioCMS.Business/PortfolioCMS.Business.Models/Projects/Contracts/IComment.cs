using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioCMS.Business.Models.Projects.Contracts
{
    public interface IComment
    {
        int Id { get; set; }

        [Required]
        string Content { get; set; }

        DateTime Created { get; set; }

        int ProjectId { get; set; }

        string Author { get; set; }    
    }
}
