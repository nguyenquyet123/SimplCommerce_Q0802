using System.Collections.Generic;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.Q0802;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class FilterOption
    {
        public IList<FilterBrand> Brands { get; set; } = new List<FilterBrand>();

        public IList<FilterCategory> Categories { get; set; } = new List<FilterCategory>();

        public FilterPrice Price { get; set; } = new FilterPrice();

        public FilterRating Rating { get; set; } = new FilterRating();
    }
}
