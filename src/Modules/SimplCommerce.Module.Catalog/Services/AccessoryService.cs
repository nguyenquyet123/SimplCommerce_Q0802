using System;
using System.Threading.Tasks;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Services
{
    public class AccessoryService : IAccessoryService
    {
        private readonly IRepository<Accessory> _accessoryRepository;

        public AccessoryService(IRepository<Accessory> accessoryReposity)
        {
            _accessoryRepository = accessoryReposity;
        }
        public void Create(Accessory accessory)
        {
            using (var transaction = _accessoryRepository.BeginTransaction())
            {
                _accessoryRepository.Add(accessory);
                _accessoryRepository.SaveChanges();

                transaction.Commit();
            }
        }

        public void Update(Accessory accessory)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Accessory accessory)
        {
            throw new NotImplementedException();
        }

    }
}
