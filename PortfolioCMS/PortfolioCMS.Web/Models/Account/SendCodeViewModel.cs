﻿using System.Collections.Generic;

namespace PortfolioCMS.Web.Models.Account
{
    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}