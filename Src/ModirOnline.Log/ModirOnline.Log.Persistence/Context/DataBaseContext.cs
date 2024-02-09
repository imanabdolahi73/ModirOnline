using ModirOnline.Log.Application.Interface;
using ModirOnline.Log.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.Log.Persistence.Context
{
    public class DataBaseContext: IDataBaseContext
    {
        private readonly IMongoDatabase _database;
        private readonly string _collectionName;

        public DataBaseContext(DatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
            _collectionName = settings.CollectionName;
            
        }

        public IMongoCollection<SysLog> SysLogs => _database.GetCollection<SysLog>(_collectionName);
    }
}

