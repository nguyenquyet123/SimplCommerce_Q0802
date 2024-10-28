using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class SearchOption
    {
        public string Query { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string Sort { get; set; }

        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }

        public int? MaxRating { get; set; }
        public int? MinRating { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            var dict = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(Query))
            {
                dict.Add("query", Query);
            }

            if (!string.IsNullOrWhiteSpace(Brand))
            {
                dict.Add("brand", Brand);
            }

            if (!string.IsNullOrWhiteSpace(Category))
            {
                dict.Add("category", Category);
            }

            if (MinPrice.HasValue)
            {
                dict.Add("minPrice", MinPrice.Value.ToString());
            }

            if (MaxPrice.HasValue)
            {
                dict.Add("maxPrice", MaxPrice.Value.ToString());
            }

            if (!string.IsNullOrWhiteSpace(Sort))
            {
                dict.Add("sort", Sort);
            }

            //task_rating
            if (MaxRating.HasValue)
            {
                dict.Add("maxRating", MaxRating.Value.ToString());
            }

            if (MinRating.HasValue)
            {
                dict.Add("minRating", MinRating.Value.ToString());
            }

            return dict;
        }

        public IList<string> GetBrands()
        {
            return string.IsNullOrWhiteSpace(Brand) ? new List<string>() : Brand.Split(new[] { "--" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public IList<string> GetCategories()
        {
            return string.IsNullOrWhiteSpace(Category) ? new List<string>() : Category.Split(new[] { "--" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public string ToJson()
        {
            var jsonSetting = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            jsonSetting.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
            return JsonConvert.SerializeObject(this, jsonSetting);
        }

        public static implicit operator SearchOption(System.IO.SearchOption v)
        {
            throw new NotImplementedException();
        }
    }
}
