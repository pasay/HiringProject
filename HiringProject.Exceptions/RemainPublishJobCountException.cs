using System;

namespace HiringProject.Exceptions
{
    public class RemainPublishJobCountException : Exception
    {
        public RemainPublishJobCountException(string key, string value) : base($"{key}[{value}] you have reached the job posting limit.")
        {

        }
    }
}
