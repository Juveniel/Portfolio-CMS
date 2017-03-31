using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PortfolioCMS.Business.Models.Content;
using PortfolioCMS.Web.App_Start.AutoMapper;

namespace PortfolioCMS.Web.Areas.Admin.Models.ContentSections
{
    public class ContentSectionViewModel : IMapFrom<PageContent>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string SectionName { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        [AllowHtml]
        public string Content { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public string Image { get; set; }
         
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ContentSectionViewModel, PageContent>()
                .ForMember(d => d.Image, src => src.MapFrom(s => ("~/Images/PageContent/" + s.ImageFile.FileName)));
        }
    }
}