using MarinosV2PrototypeShared.BaseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MarinosV2PrototypeShared.Utils;

public class CustomContractResolver : DefaultContractResolver
{

    protected override IList<JsonProperty> CreateProperties(Type? type, MemberSerialization memberSerialization)
    {
        while (type != null && type.Assembly != GetType().Assembly)
            type = type.BaseType;
        return base.CreateProperties(type, memberSerialization).Where(_ => !typeof(TrackedEntity).GetProperties().Select(__ => __.Name).Contains(_.PropertyName)).ToList();
    }
}