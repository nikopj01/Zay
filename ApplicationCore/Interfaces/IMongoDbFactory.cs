using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zay.ApplicationCore.Interfaces
{
    public interface IMongoDbFactory
    {
        IMongoCollection<T> GetCollection<T>(string databaseName, string collectionNme);
    }
}
