using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Authorize(Roles = "Admin, User")]
    [Area("Catalog")]
    [Route("api/accessories")]
    [ApiController]
    public class AccessoryApiController : ControllerBase
    {
        private readonly IRepository<Accessory> _accessoryRepository;
        private readonly AccessoryService _accessoryService;

        public AccessoryApiController(IRepository<Accessory> accessoryRepository, AccessoryService accessoryService)
        {
            _accessoryRepository = accessoryRepository;
            _accessoryService = accessoryService;
        }


        //[HttpPost]
        //public async  Task<IActionResult> Post(Accessory model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var accessory = new Accessory
        //        {
        //            Name = model.Name,
        //            Slug = model.Slug,
        //            BrandId = model.BrandId,
        //            Price = model.Price,
        //            OldPrice = model.OldPrice,
        //            SpecialPrice = model.SpecialPrice,
        //            SpecialPriceEnd = model.SpecialPriceEnd,
        //            SpecialPriceStart = model.SpecialPriceStart,
        //            IsCallForPricing = model.IsCallForPricing,
        //            ImgName = model.ImgName,
        //            Description = model.Description,
        //            ReviewsCount = model.ReviewsCount,
        //        };
        //        _accessoryService.Create(accessory);
        //        return Created();
        //        //CreatedAtAction(nameof(Get), new { id = category.Id }, null);
        //    }

        //    return BadRequest(ModelState);
        //}
    }
}
