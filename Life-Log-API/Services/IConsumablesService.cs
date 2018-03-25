using Life_Log_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Life_Log_API.Services
{
    public interface IConsumablesService
    {
        IEnumerable<Consumable> Get();
        Consumable Post(Consumable consumableToAdd);
    }
}
