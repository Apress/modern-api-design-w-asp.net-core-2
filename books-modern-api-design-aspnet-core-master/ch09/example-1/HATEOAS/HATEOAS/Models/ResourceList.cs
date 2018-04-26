using Newtonsoft.Json;
using System.Collections.Generic;

namespace HATEOAS.Models
{
    public class ResourceList<T>
    {
        public ResourceList(List<T> items)
        {
            this.Items = items;
        }
        public List<T> Items { get; }
        [JsonProperty("_links", Order = -2)]
        public List<Link> Links { get; } = new List<Link>();
    }
}
