namespace WireMockExample.Api.Settings
{
    public sealed class MongoDBSettings
    {
        public string Database { get; set; }
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
    }
}