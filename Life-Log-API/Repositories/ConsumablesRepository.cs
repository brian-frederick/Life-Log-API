using Life_Log_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_Log_API.Repositories
{
    public class ConsumablesRepository : IConsumablesRepository
    {
        private readonly List<Consumable> _consumables;

        public ConsumablesRepository(IEnumerable<Consumable> consumables)
        {
            if (consumables == null)
            {
                throw new ArgumentNullException(nameof(consumables));
            }
            _consumables = new List<Consumable>(consumables);
        }

        public IEnumerable<Consumable> Get()
        { 
            return _consumables;
        }
    }
}
