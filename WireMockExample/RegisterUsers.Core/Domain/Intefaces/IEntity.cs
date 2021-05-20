using System;
using MongoDB.Bson;

namespace RegisterUsers.Core.Domain.Intefaces
{
    public interface IEntity
    {
        string ContextId { get; set; }
        string Id { get; set; }
    }
}