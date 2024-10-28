using System.Threading.Tasks;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Services
{
    public interface IAccessoryService
    {
        void Create(Accessory accessory);

        void Update(Accessory accessory);

        Task Delete(long id);

        Task Delete(Accessory accessory);

    }
}
