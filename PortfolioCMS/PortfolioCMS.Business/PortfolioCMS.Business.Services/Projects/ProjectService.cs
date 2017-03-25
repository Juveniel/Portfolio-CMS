using System.Linq;
using Bytes2you.Validation;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Models.Projects;
using PortfolioCMS.Business.Services.Projects.Contracts;

namespace PortfolioCMS.Business.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IEFRepository<Project> projectRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProjectService(IEFRepository<Project> projectRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(projectRepository, "Project repository is null!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

            this.projectRepository = projectRepository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Project> GetAllProjects()
        {
            return this.projectRepository.All();
        }

        public void AddProject(Project projectToAdd)
        {
            Guard.WhenArgument(projectToAdd, "Project to add is null").IsNull().Throw();

            using (var uow = this.unitOfWork)
            {
                this.projectRepository.Add(projectToAdd);
                uow.SaveChanges();
            }
        }
    }
}
