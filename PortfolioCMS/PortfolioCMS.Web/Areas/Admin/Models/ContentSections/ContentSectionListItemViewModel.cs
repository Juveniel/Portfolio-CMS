using AutoMapper;
using PortfolioCMS.Business.Models.Content;
using PortfolioCMS.Web.App_Start.AutoMapper;

namespace PortfolioCMS.Web.Areas.Admin.Models.ContentSections
{
    public class ContentSectionListItemViewModel : IMapFrom<PageContent>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string SectionName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PageContent, ContentSectionListItemViewModel>();
        }
    }
}