
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.Q0802;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Core.Services;
using SearchOption = SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.SearchOption;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AccessoryController : Controller
    {
        private readonly IRepository<Accessory> _accessoriesRepository;

        private int _pageSize;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IProductPricingService _productPricingService;
        private readonly IContentLocalizationService _contentLocalizationService;

        public AccessoryController(IRepository<Category> categoryRepository,
            IProductPricingService productPricingService,
            IConfiguration config,
            IContentLocalizationService contentLocalizationService,
            IRepository<Accessory> accessoriesRepository)
        {
            _accessoriesRepository = accessoriesRepository;

            _categoryRepository = categoryRepository;
            _productPricingService = productPricingService;
            _contentLocalizationService = contentLocalizationService;
            _pageSize = config.GetValue<int>("Catalog.ProductPageSize");
        }

        public IActionResult AccessoryDetail(long id, SearchOption searchOption)
        {
            var category = _categoryRepository.Query().FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var model = new AccessoryByCategory
            {
                CategorySlug = category.Slug,
                CategoryId = category.Id,
                ParentCategorId = category.ParentId,
                CategoryName = _categoryRepository.Query().Where(q => q.Id == id).Select(q => q.Name).FirstOrDefault(),
                CurrentSearchOption = searchOption,
                FilterOption = new FilterOption()
            };

            var query = _accessoriesRepository.Query();

            AppendFilterOptionsToModel(model, query);

            if (searchOption.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= searchOption.MinPrice.Value);
            }

            if (searchOption.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= searchOption.MaxPrice.Value);
            }

            //task_rating

            if (searchOption.MinRating.HasValue)
            {
                query = query.Where(q => q.RatingAverage >= searchOption.MinRating.Value);
            }

            if (searchOption.MaxRating.HasValue)
            {
                query = query.Where(q => q.RatingAverage >= searchOption.MaxRating.Value);
            }

            var brands = searchOption.GetBrands().ToArray();
            if (brands.Any())
            {
                query = query.Where(x => x.BrandId != null && brands.Contains(x.Brand.Slug));
            }

            query = ApplySort(searchOption, query);

            var accessories = query.Select(a => AccessoryThumbnail.FromAccessory(a)).ToList();
            foreach (var accessory in accessories)
            {
                accessory.CalculatedProductPrice = _productPricingService.CalculateAccessoryPrice(accessory);
            }

            model.TotalProduct = query.Count();
            model.Accessories = accessories;
            return View(model);
        }
        private static IQueryable<Accessory> ApplySort(SearchOption searchOption, IQueryable<Accessory> query)
        {
            var sortBy = searchOption.Sort ?? string.Empty;
            switch (sortBy.ToLower())
            {
                case "price-desc":
                    query = query.OrderByDescending(x => x.Price);
                    break;
                default:
                    query = query.OrderBy(x => x.Price);
                    break;
            }

            return query;
        }

        private void AppendFilterOptionsToModel(AccessoryByCategory model, IQueryable<Accessory> query)
        {
            model.FilterOption.Price.MaxPrice = query.Max(x => x.Price);
            model.FilterOption.Price.MinPrice = query.Min(x => x.Price);

            //task_rating
            model.FilterOption.Rating.MinRating = query.Min(q => q.RatingAverage);
            model.FilterOption.Rating.MaxRating = query.Max(q => q.RatingAverage);

            //var getCategoryName = _contentLocalizationService.GetLocalizationFunction<Category>();

            //model.FilterOption.Categories = query
            //    .SelectMany(x => x.Accessories)
            //    .GroupBy(x => new
            //    {
            //        x.Category.Id,
            //        x.Category.Name,
            //        x.Category.Slug,
            //        x.Category.ParentId
            //    })
            //    .Select(g => new FilterCategory
            //    {
            //        Id = (int)g.Key.Id,
            //        Name = g.Key.Name,
            //        Slug = g.Key.Slug,
            //        ParentId = g.Key.ParentId,
            //        Count = g.Count()
            //    }).ToList();

            //foreach (var item in model.FilterOption.Categories)
            //{
            //    item.Name = getCategoryName(item.Id, nameof(item.Name), item.Name);
            //}

            model.FilterOption.Brands = query.Include(x => x.Brand)
                .Where(x => x.BrandId != null).ToList()
                .GroupBy(x => x.Brand)
                .Select(g => new FilterBrand
                {
                    Id = g.Key.Id,
                    Name = g.Key.Name,
                    Slug = g.Key.Slug,
                    Count = g.Count()
                }).ToList();
        }
    }
}
