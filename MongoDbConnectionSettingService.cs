using System;
using System.Collections.Generic;
using System.Configuration;
using MongoDB.Driver;

namespace MongoDbClient
{
    public class MongoDbConnectionSettingService : IMongoDbConnectionSettingService
    {
        public IMongoClient MongoClient { get; private set; }

        public MongoDbConnectionSettingService(IMongoConnection mongoConnection)
        {
            var mongoCredential = MongoCredential.CreateCredential(mongoConnection.AuthDatabase, mongoConnection.Username, mongoConnection.Password);
            var mongoClientSettings = new MongoClientSettings { Credential = mongoCredential };
            var mongoServerAddress = new MongoServerAddress(mongoConnection.Host, mongoConnection.Port);
            mongoClientSettings.Server = mongoServerAddress;
            mongoClientSettings.UseSsl = true; 
            MongoClient = new MongoClient(mongoClientSettings);
        }

    }
}