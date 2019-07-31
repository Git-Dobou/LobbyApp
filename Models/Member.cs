using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App.Models {
    public class Member {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirdDay { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PassWord { get; set; }
        public Address Address { get; set; }
        public DateTime Date_Session { get; set; }
        public double Debt { get; set; }
        public double To_Pay_Open { get; set; }
        public double To_Pay { get; set; }
        public string Image { get; set; }
    }
}