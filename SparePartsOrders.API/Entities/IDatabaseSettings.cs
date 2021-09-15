using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsOrders.API.Entities
{
    public interface IDatabaseSettings
    {
        string OrdersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
