using WireMockExample.Api.Domains.Base;

namespace WireMockExample.Api.Domains.Entities
{
    public sealed class User : Entity
    {
        public string Name { get; set; }
        public int Followers { get; set; }
    }
}