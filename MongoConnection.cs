using System.Configuration;

namespace MongoDbClient
{
    public class MongoConnection : IMongoConnection
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string AuthDatabase { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }
    }
}
