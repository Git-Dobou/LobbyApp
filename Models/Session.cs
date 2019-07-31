using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App.Models
{
    public enum Type
    {
        Late_Arrival,
        Disturbance,
        Cotisation,
        Other
    }
    public struct Penalty
    {
        public Type Type;
        public double Sum;
        public string Comment;
        public Member Member { get; set; }
    }
    public class Session
    {
        public ObjectId Id { get; set; }
        public DateTime Date { get; set; }
        public Member Member { get; set; }
        public Address Address { get; set; }
        public List<Penalty> Penaltys { get; set; }
        public string Infos { get; set; }
        public string Report { get; internal set; }
    }
}