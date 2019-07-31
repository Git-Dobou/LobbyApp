using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using App.Interfaces;
using App.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace App.Services {
    public class MemberService : IMemberService {
        private List<Member> cachedMembers = new List<Member> ();
        private readonly IDatabaseService _databaseService;
        public MemberService (IDatabaseService databaseService) {
            _databaseService = databaseService;

            Members = new ObservableCollection<Member> ();
            LoadMemberFromDb ();
        }
        public ObservableCollection<Member> Members { get; }

        public Member GetmemberWithUserName (string userName) {
            if (string.IsNullOrEmpty (userName))
                return null;

            return Members.FirstOrDefault (member => member.UserName == userName);
        }

        public Member GetmemberWithId (ObjectId id) {
            return Members.FirstOrDefault (member => ObjectId.Equals(member.Id, id));
        }

        private void LoadMemberFromDb () {
            var collection = _databaseService.GetCollection<BsonDocument> ("appdb", "Member");
            var documents = collection.Find (new BsonDocument ()).ToList ();

            foreach (var document in documents) {
                var member = new Member {
                    Id = document["_id"].AsObjectId,
                    FirstName = document["FirstName"].AsString,
                    LastName = document["LastName"].AsString,
                    PasswordHash = document["PasswordHash"].AsString,
                    UserName = document["UserName"].AsString,
                    BirdDay = document["BirdDay"].ToUniversalTime (),
                    To_Pay = document["To_Pay"].AsDouble,
                    To_Pay_Open = document["To_Pay_Open"].AsDouble,
                    Debt = document["Debt"].AsDouble,
                    Date_Session = document["Date_Session"].ToUniversalTime (),
                    Image = document["Image"].AsString,
                    Address = new Address {
                    Street = document["Address"]["Street"].AsString,
                    Code = document["Address"]["Code"].AsString,
                    City = document["Address"]["City"].AsString,
                    Mobile = document["Address"]["Mobile"].AsString,
                    }
                };

                Members.Add (member);
            }
        }

        public void RegisterMember (Member member) {

            if (member == null || member.Address == null)
                return;

            var collectionMember = _databaseService.GetCollection<Member> ("appdb", "Member");

            member.Id = ObjectId.GenerateNewId ();
            collectionMember.InsertOne (member);
        }
    }
}