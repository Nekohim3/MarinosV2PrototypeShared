using MarinosV2PrototypeShared.BaseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MarinosV2PrototypeShared.Utils;

public class CustomContractResolver : DefaultContractResolver
{

    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        IList<JsonProperty> properties    = base.CreateProperties(type, memberSerialization);
        var                 propsToIgnore = typeof(TrackedEntity).GetProperties().Select(p => p.Name).ToList();

        properties =
            properties.Where(p => !propsToIgnore.Contains(p.PropertyName)).ToList();

        return properties;
    }
}