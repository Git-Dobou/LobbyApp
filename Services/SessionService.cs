using System;
using System.Collections.ObjectModel;
using System.Linq;
using App.Interfaces;
using App.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace App.Services {
    public class SessionService : ISessionService {
        private readonly IDatabaseService _databaseService;
        private readonly IMemberService _memberService;

        public SessionService (IDatabaseService databaseService, IMemberService memberService) {
            _memberService = memberService;
            _databaseService = databaseService;

            Sessions = new ObservableCollection<Session> ();
            LoadSessionFromDb ();
        }

        public Session GetSession (ObjectId id) {
            return Sessions.FirstOrDefault (session => ObjectId.Equals (session.Id, id));
        }

        public ObservableCollection<Session> Sessions { get; }

        private void LoadSessionFromDb () {
            var collection = _databaseService.GetCollection<BsonDocument> ("appdb", "Session");
            var documents = collection.Find (new BsonDocument ()).ToList ();

            foreach (var document in documents) {
                var session = new Session {
                    Id = document["_id"].AsObjectId,
                    Date = document["Date"].ToUniversalTime (),
                    Member = _memberService.GetmemberWithId (document["Member"]["Member_Id"].AsObjectId),
                    Address = new Address {
                    Street = document["Address"]["Street"].AsString,
                    Code = document["Address"]["Code"].AsString,
                    City = document["Address"]["City"].AsString,
                    Mobile = document["Address"]["Mobile"].AsString,
                    },
                    Penaltys = document["Penaltys"].AsBsonArray.Select (penalty => {
                        return new Penalty {
                            Member = _memberService.GetmemberWithId (penalty["Member_Id"].AsObjectId),
                            Type = (App.Models.Type) Enum.Parse (typeof (App.Models.Type), penalty["Type"].AsString),
                            Sum = penalty["Sum"].AsDouble,
                            Comment = penalty["Comment"].AsString
                        };
                    }).ToList (),
                    Infos = document["Info"].AsString,
                    Report = document["Report"].AsString,
                };

                Sessions.Add (session);
            }
        }
    }
}