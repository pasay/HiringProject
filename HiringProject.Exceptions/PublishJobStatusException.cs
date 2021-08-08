using System;

namespace HiringProject.Exceptions
{
    public class PublishJobStatusException : Exception
    {
        public PublishJobStatusException(string key, string value) : base($"{key}[{value}] Only posts with 'Created' status can be published.")
        {

        }
    }
}
