using log4net.ElasticSearch;
using Microsoft.Extensions.Configuration;

namespace IoTRynningeasenWWW
{
    public class ElasticAppender : ElasticSearchAppender
    {
        public new string ConnectionString { get; set; }

        public ElasticAppender()
        {
            base.ConnectionString = Startup.Configuration.GetConnectionString("ElasticAppender");
        }
    }

    public class RawSensorsAppender : ElasticSearchAppender
    {
        public new string ConnectionString { get; set; }

        public RawSensorsAppender()
        {
            base.ConnectionString = Startup.Configuration.GetConnectionString("RawSensorsAppender");
        }
    }
}