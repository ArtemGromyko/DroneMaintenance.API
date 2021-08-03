using System;

namespace DroneMaintenance.BLL.Exceptions
{
    public class EntityNotFoundException : ArgumentException
    {
        public EntityNotFoundException(string message) : base(message)
        { }
    }
}
