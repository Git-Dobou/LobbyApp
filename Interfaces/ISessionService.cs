using System.Collections.ObjectModel;
using App.Models;
using MongoDB.Bson;

namespace App.Interfaces
{
    public interface ISessionService
    {
         ObservableCollection<Session> Sessions {get;}
         Session GetSession(ObjectId id);
    }
}