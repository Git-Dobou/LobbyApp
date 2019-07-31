using System.Collections.ObjectModel;
using App.Models;
using MongoDB.Bson;

namespace App.Interfaces {
    public interface IMemberService {
        ObservableCollection<Member> Members { get; }
        Member GetmemberWithUserName (string userName);
        Member GetmemberWithId (ObjectId id);
        void RegisterMember (Member member);
    }
}