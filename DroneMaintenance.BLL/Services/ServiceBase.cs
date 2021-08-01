using DroneMaintenance.BLL.Exceptions;
using System;

namespace DroneMaintenance.BLL.Services
{
    public abstract class ServiceBase
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

    }
}
