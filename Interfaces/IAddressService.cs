using App.Models;
using MongoDB.Bson;

namespace App.Interfaces
{
    public interface IAddressService
    {
         Address GetAddress(ObjectId id);
    }
}