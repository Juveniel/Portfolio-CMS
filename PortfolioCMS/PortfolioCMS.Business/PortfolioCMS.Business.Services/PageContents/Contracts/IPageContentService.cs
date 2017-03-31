using System.Linq;
using PortfolioCMS.Business.Models.Content;

namespace PortfolioCMS.Business.Services.PageContents.Contracts
{
    public interface IPageContentService
    {
        IQueryable<PageContent> GetAllPageContents();

        PageContent FindById(int id);

        PageContent FindBySectionName(string section);

        void CreatePageContent(PageContent contentToAdd);

        void UpdatePageContent(PageContent contentToUpdate);
    }
}