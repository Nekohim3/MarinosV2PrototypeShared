using MarinosV2PrototypeShared.BaseModels;
using Newtonsoft.Json;

namespace MarinosV2PrototypeShared.Utils
{
    [JsonObject]
    public class ServicePackage<T> where T : Entity
    {
        public List<string> Includes { get; set; }
        public T            Entity   { get; set; }
    }

    [JsonObject]
    public class ServiceListPackage<T> where T : List<Entity>
    {
        public List<string> Includes { get; set; }
        public T            EntityList   { get; set; }
    }
}
