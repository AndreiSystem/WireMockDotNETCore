using System;
using MongoDB.Bson.Serialization.Attributes;
using RegisterUsers.Core.Domain.Base;

namespace RegisterUsers.Core.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public sealed class User : Entity
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}