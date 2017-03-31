using System.Web.Mvc;
using Bytes2you.Validation;
using PortfolioCMS.Business.Services.Images.Contracts;
using PortfolioCMS.Business.Services.Mappings.Contracts;

namespace PortfolioCMS.Web.Areas.Admin.Controllers.Base
{
    public class BaseController : Controller
    {
        private IMappingService mappingService;
        private IImageService imageService;

        public BaseController(IMappingService mappingService, IImageService imageService)
        {
            Guard.WhenArgument(mappingService, "Mapping service is null.").IsNull().Throw();
            Guard.WhenArgument(imageService, "Image service is null.").IsNull().Throw();

            this.mappingService = mappingService;
            this.imageService = imageService;
        }

        public IMappingService MappingService
        {
            get
            {
                return this.mappingService;
            }
        }

        public IImageService ImageService
        {
            get
            {
                return this.imageService;
            }
        }
    }
}