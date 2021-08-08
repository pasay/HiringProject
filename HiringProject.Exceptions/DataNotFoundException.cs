using System;

namespace HiringProject.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string key, string value) : base($"{key}[{value}] data not found.")
        {

        }
    }
}
