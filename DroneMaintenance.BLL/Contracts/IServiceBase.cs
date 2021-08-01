using System;

namespace DroneMaintenance.BLL.Contracts
{
    public interface IServiceBase
    {
        void CheckEntityExistence(Guid id, object entity, string entityName);
        void CheckEntityExistence(Guid parentId, Guid id, object entity, string entityName, string parentEntityName);
    }
}
