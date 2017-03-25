using System;
using System.Collections.Generic;
using PortfolioCMS.Business.Common.Enumerations;

namespace PortfolioCMS.Business.Models.Projects.Contracts
{
    public interface IProject
    {
        int Id { get; set; }

        string Title { get; set; }

        string Subtitle { get; set; }

        string Description { get; set; }

        DateTime DateStarted { get; set; }

        DateTime DateFinished { get; set; }

        ProjectCategory Category { get; set; }

        string DemoUrl { get; set; }

        DateTime Published { get; set; }

        ICollection<Comment> Comments { get; set; }

        ICollection<Image> Images { get; set; }

        ICollection<Tag> Tags { get; set; }
    }
}
