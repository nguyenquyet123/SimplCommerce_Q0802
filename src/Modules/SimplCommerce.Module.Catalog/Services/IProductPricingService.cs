using System;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.Q0802;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Services
{
    public interface IProductPricingService
    {
        public CalculatedProductPrice CalculateAccessoryPrice(AccessoryThumbnail accessoryThumbnail);
        CalculatedProductPrice CalculateProductPrice(ProductThumbnail productThumbnail);

        CalculatedProductPrice CalculateProductPrice(Product product);

        CalculatedProductPrice CalculateProductPrice(decimal price, decimal? oldPrice, decimal? specialPrice, DateTimeOffset? specialPriceStart, DateTimeOffset? specialPriceEnd);
    }
}
