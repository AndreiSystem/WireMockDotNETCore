using System;
using WireMockExample.Api.Domains.Interfaces;

namespace WireMockExample.Api.Domains.Base
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}