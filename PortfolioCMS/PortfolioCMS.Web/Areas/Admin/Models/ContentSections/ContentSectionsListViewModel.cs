using System.Collections.Generic;

namespace PortfolioCMS.Web.Areas.Admin.Models.ContentSections
{
    public class ContentSectionsListViewModel
    {
        public IEnumerable<ContentSectionListItemViewModel> ContentSections { get; set; }
    }
}