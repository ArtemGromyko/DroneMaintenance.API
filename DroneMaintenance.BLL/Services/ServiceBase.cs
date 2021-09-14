using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.BLL.Exceptions;
using System;

namespace DroneMaintenance.BLL.Services
{
    public abstract class ServiceBase : IServiceBase
    {
        public void CheckEntityExistence(Guid id, object entity, string entityName)
        {
            if (entity == null)
            {
                throw new EntityNotFoundException($"{entityName} with id: {id} doesn't exist in the database.");
            }
        }

        public void CheckEntityExistence(Guid parentId, Guid id, object entity, string entityName, string parentEntityName)
        {
            if (entity == null)
            {
                throw new EntityNotFoundException($"{entityName} with id: {id} and {parentEntityName} id: {parentId} doesn't exist in the database.");
            }
        }
        
        public void CheckEntityExistence(Guid firstId, Guid secondId, object entity, string entityName)
        {
            if (entity == null)
            {
                throw new EntityNotFoundException($"{entityName} with {nameof(firstId)} and {nameof(secondId)} doesn't exist in the database.");
            }
        }
    }
}
