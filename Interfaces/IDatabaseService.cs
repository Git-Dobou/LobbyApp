using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace App.Interfaces
{
    public interface IDatabaseService
    {
        IMongoCollection<T> GetCollection<T>(string databaseName, string collectionName);
    }
}