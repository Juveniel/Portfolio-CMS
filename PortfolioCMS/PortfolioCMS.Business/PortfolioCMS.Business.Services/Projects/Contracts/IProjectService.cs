using System.Linq;
using PortfolioCMS.Business.Models.Projects;

namespace PortfolioCMS.Business.Services.Projects.Contracts
{
    public interface IProjectService
    {
        IQueryable<Project> GetAllProjects();

        void AddProject(Project destinationToAdd);
    }
}