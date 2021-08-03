using System;

namespace DroneMaintenance.BLL.Exceptions
{
    public class ForbiddenActionException : Exception
    {
        public ForbiddenActionException(string message) : base(message)
        {

        }
    }
}
