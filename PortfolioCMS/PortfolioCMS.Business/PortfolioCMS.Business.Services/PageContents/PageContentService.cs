using System.Linq;
using Bytes2you.Validation;
using PortfolioCMS.Business.Models.Content;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Services.PageContents.Contracts;

namespace PortfolioCMS.Business.Services.PageContents
{
    public class PageContentService : IPageContentService
    {
        private readonly IEFRepository<PageContent> pageContentRepository;
        private readonly IUnitOfWork unitOfWork;

        public PageContentService(IEFRepository<PageContent> pageContentRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(pageContentRepository, "Destination repository is null!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

            this.pageContentRepository = pageContentRepository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<PageContent> GetAllPageContents()
        {
            return this.pageContentRepository.All();
        }

        public PageContent FindBySectionName(string section)
        {
            return this.pageContentRepository.GetFirst(x => x.SectionName == section);
        }

        public PageContent FindById(int id)
        {
            return this.pageContentRepository.GetFirst(x => x.Id == id);
        }


        public void CreatePageContent(PageContent contentToAdd)
        {
            Guard.WhenArgument(contentToAdd, "Content to add is null").IsNull().Throw();

            using (var uow = this.unitOfWork)
            {
                this.pageContentRepository.Add(contentToAdd);
                uow.SaveChanges();
            }
        }

        public void UpdatePageContent(PageContent contentToUpdate)
        {
            Guard.WhenArgument(contentToUpdate, "Content to update cannot be null").IsNull().Throw();

            using (var uow = this.unitOfWork)
            {
                this.pageContentRepository.Update(contentToUpdate);
                uow.SaveChanges();
            }
        }

    }
}
