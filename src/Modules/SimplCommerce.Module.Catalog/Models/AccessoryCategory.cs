using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class AccessoryCategory : EntityBase
    {
        public bool? IsFeaturedAccessory { get; set; }

        public int? DisplayOrder { get; set; }

        public long CategoryId { get; set; }

        public long AccessorId { get; set; }

        public Category Category { get; set; }

        public Accessory accessory { get; set; }
    }
}
