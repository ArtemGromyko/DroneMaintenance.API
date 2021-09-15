using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsOrders.API.Entities
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
