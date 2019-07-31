using System;
using App.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace App.Services
{
    public class DatabaseService : IDatabaseService
    {
        MongoClient dbClient;

        public DatabaseService()
        {
            dbClient = new MongoClient("mongodb://127.0.0.1:27017");
        }
        IMongoDatabase GetDatabase(string databaseName)
        {
            return dbClient.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string databaseName, string collectionName)
        {
            var db = GetDatabase(databaseName);
            var collection = db.GetCollection<T>(collectionName);

            return collection;
        }
    }
}