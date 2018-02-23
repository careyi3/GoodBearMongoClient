using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbClient
{
    public interface IMongoDbConnectionSettingService
    {
        IMongoClient MongoClient { get; }
    }
}
