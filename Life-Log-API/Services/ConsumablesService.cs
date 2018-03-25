using Life_Log_API.Models;
using Life_Log_API.Services;
using Life_Log_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_Log_API.Services
{
    public class ConsumablesService: IConsumablesService
    {
        private readonly IConsumablesRepository _consumablesRepository;

        public ConsumablesService(IConsumablesRepository consumablesRepository)
        {
            _consumablesRepository = consumablesRepository ?? throw new ArgumentNullException(nameof(consumablesRepository));
        }
        public IEnumerable<Consumable> Get()
        {
            var allConsumables = _consumablesRepository.Get();

            return allConsumables;
        }

        public Consumable Post(Consumable consumableToAdd)
        {
            var addedConsumable = _consumablesRepository.Post(consumableToAdd);

            return addedConsumable;
        }
    }
}
