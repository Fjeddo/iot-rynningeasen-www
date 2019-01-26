using System;

namespace iot_rynningeasen_www
{
    public class UnknownTopicException : Exception
    {
        public UnknownTopicException(string eTopic) : base(eTopic)
        {}
    }
}