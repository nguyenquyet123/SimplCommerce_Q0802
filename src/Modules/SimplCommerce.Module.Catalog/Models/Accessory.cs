using System;
using System.Collections.Generic;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class Accessory : EntityBase
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public bool IsCallForPricing { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? SpecialPrice { get; set; }

        public DateTimeOffset? SpecialPriceStart { get; set; }

        public DateTimeOffset? SpecialPriceEnd { get; set; }

        public double? RatingAverage { get; set; }

        public int ReviewsCount { get; set; }

        public bool IsAllowToOrder { get; set; }

        public int? StockQuantity { get; set; }

        public long ThumbnailImageId { get; set; }

        public long? BrandId { get; set; }

        public Brand Brand { get; set; }

        public long? TaxClassId { get; set; }

        public long? CreatedById { get; set; }

        public long? LatestUpdatedById { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string ImgName { get; set; }

        public IList<AccessoryCategory> Accessories { get; protected set; } = new List<AccessoryCategory>();
    }
}
