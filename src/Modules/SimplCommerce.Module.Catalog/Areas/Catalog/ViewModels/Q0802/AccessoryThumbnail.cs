using System;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.Q0802
{
    public class AccessoryThumbnail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? SpecialPrice { get; set; }

        public bool IsCallForPricing { get; set; }

        public bool IsAllowToOrder { get; set; }

        public int? StockQuantity { get; set; }

        public DateTimeOffset? SpecialPriceStart { get; set; }

        public DateTimeOffset? SpecialPriceEnd { get; set; }

        public long ThumbnailImage { get; set; }

        public string ThumbnailUrl { get; set; }

        public int ReviewsCount { get; set; }

        public double? RatingAverage { get; set; }

        public string ImgName { get; set; }

        public CalculatedProductPrice CalculatedProductPrice { get; set; }

        public static AccessoryThumbnail FromAccessory(Accessory accessory)
        {
            var accessoryThumbnail = new AccessoryThumbnail
            {
                Id = accessory.Id,
                Name = accessory.Name,
                Slug = accessory.Slug,
                Price = accessory.Price,
                OldPrice = accessory.OldPrice,
                SpecialPrice = accessory.SpecialPrice,
                SpecialPriceStart = accessory.SpecialPriceStart,
                SpecialPriceEnd = accessory.SpecialPriceEnd,
                StockQuantity = accessory.StockQuantity,
                IsAllowToOrder = accessory.IsAllowToOrder,
                IsCallForPricing = accessory.IsCallForPricing,
                ThumbnailImage = accessory.ThumbnailImageId,
                ReviewsCount = accessory.ReviewsCount,
                RatingAverage = accessory.RatingAverage,
                ImgName = accessory.ImgName,
            };

            return accessoryThumbnail;
        }
    }
}
