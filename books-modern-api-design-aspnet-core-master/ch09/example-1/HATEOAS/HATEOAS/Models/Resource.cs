using Newtonsoft.Json;
using System.Collections.Generic;

namespace HATEOAS.Models
{
    public abstract class Resource
    {
        [JsonProperty("_links", Order = -2)]
        public List<Link> Links { get; } = new List<Link>();
    }
}
