using System;

namespace App.Models
{
    public class TranslatorObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value{get; set;}

        public static TranslatorObject NullObject = new TranslatorObject{
            Id = Guid.Empty.ToString(),
            Name = string.Empty,
            Value = string.Empty
        };
    }
}