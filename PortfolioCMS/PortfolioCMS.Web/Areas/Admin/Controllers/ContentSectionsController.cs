using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using PortfolioCMS.Business.Models.Content;
using PortfolioCMS.Business.Services.Images.Contracts;
using PortfolioCMS.Business.Services.Mappings.Contracts;
using PortfolioCMS.Business.Services.PageContents.Contracts;
using PortfolioCMS.Web.Areas.Admin.Controllers.Base;
using PortfolioCMS.Web.Areas.Admin.Models.ContentSections;

namespace PortfolioCMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ContentSectionsController : BaseController
    {
        private IPageContentService pageContentService;

        public ContentSectionsController(IPageContentService pageContentService, IMappingService mappingService, IImageService imageService)
			:base(mappingService, imageService)
		{
            Guard.WhenArgument(pageContentService, "PageContent service is null.").IsNull().Throw();

            this.pageContentService = pageContentService;
        }

        // GET: Admin/ContentSections
        public ActionResult Index()
        {
            var sections = pageContentService.GetAllPageContents().ProjectTo<ContentSectionListItemViewModel>();

            var pageSections = new ContentSectionsListViewModel { ContentSections = sections };

            return View(pageSections);
        }

        // GET: Admin/ContentSections/Create
        public ActionResult Create()
        {
            return View();
        }

        // Post: Admin/ContentSections/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult Create(ContentSectionViewModel newContentSection)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(newContentSection);
            }

            var contentToAdd = this.MappingService.Map<ContentSectionViewModel, PageContent>(newContentSection);

            var imageProcessed = this.ImageService.ProcessImage(newContentSection.ImageFile);
            if (!imageProcessed)
            {
                ModelState.AddModelError("Image", "The was a problem with your image!");
            }
            
            this.pageContentService.CreatePageContent(contentToAdd);

            return Redirect("/Admin/ContentSections");
        }

        // GET: Admin/ContentSections/Edit
        public ActionResult Edit(int id)
        {
            var sectionToEdit = pageContentService.FindById(id);

            var foundSection = new ContentSectionViewModel
            {
                Id = sectionToEdit.Id,
                SectionName = sectionToEdit.SectionName,
                Title = sectionToEdit.Title,
                Content = sectionToEdit.Content,
                Image = sectionToEdit.Image,
                ImageFile = null
            };

            return View(foundSection);
        }

        // Post: Admin/ContentSections/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult Edit(ContentSectionViewModel contentSection)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(contentSection);
            }

            var contentToEdit = this.MappingService.Map<ContentSectionViewModel, PageContent>(contentSection);

            var imageProcessed = this.ImageService.ProcessImage(contentSection.ImageFile);
            if (!imageProcessed)
            {
                ModelState.AddModelError("Image", "The was a problem with your image!");
            }
     
            this.pageContentService.UpdatePageContent(contentToEdit);

            return Redirect("/Admin/ContentSections");
        }
    }
}