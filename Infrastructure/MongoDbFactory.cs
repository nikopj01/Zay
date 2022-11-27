﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zay.ApplicationCore.Interfaces;

namespace Zay.Infrastructure
{
    public class MongoDbFactory : IMongoDbFactory
    {
        private readonly IMongoClient _client;

        public MongoDbFactory(string connectionString)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            _client = new MongoClient(settings);
        }

        public IMongoCollection<T> GetCollection<T>(string databaseName, string collectionName)
        {
            return _client.GetDatabase(databaseName).GetCollection<T>(collectionName);
        }
    }
}
