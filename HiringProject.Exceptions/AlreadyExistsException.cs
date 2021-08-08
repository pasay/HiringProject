using System;

namespace HiringProject.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string key, string value) : base($"{key}[{value}] already exists exception.")
        {

        }
    }
}
