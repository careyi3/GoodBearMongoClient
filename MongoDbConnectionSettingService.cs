using System;
using System.Collections.Generic;
using System.Configuration;
using MongoDB.Driver;

namespace MongoDbClient
{
    public class MongoDbConnectionSettingService : IMongoDbConnectionSettingService
    {
        private MongoClientSettings _mongoClientSettings;
        private MongoCredential _mongoCredential;
        private MongoServerAddress _mongoServerAddress;

        public MongoDbConnectionSettingService(MongoConnection connection)
        {
            ConfigureClient(connection);
        }

        public IMongoClient MongoClient { get; private set; }

        private void ConfigureClient(IMongoConnection mongoConfig)
        {
            _mongoCredential = MongoCredential.CreateCredential(mongoConfig.AuthDatabase, mongoConfig.Username, mongoConfig.Password);
            _mongoClientSettings = new MongoClientSettings { Credential = _mongoCredential };
            _mongoServerAddress = new MongoServerAddress(mongoConfig.Host, mongoConfig.Port);
            _mongoClientSettings.Server = _mongoServerAddress;
            MongoClient = new MongoClient(_mongoClientSettings);
        }

    }
}