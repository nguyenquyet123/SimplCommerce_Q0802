using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.Q0802
{
    public class AccessoryByCategory
    {
        public string CategorySlug { get; set; }
        public long CategoryId { get; set; }
        public long? ParentCategorId { get; set; }
        public string CategoryName { get; set; }
        public int TotalProduct { get; set; }

        public IList<AccessoryThumbnail> Accessories { get; set; } = new List<AccessoryThumbnail>();

        public SearchOption CurrentSearchOption { get; set; }

        public FilterOption FilterOption { get; set; }

        public IList<SelectListItem> AvailableSortOptions => new List<SelectListItem>
        {
            new SelectListItem { Text = "Price: Low to High", Value = "price-asc" },
            new SelectListItem { Text = "Price: High to Low", Value = "price-desc" }
        };
    }
}
