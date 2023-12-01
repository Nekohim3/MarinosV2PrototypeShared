using MarinosV2PrototypeShared.BaseModels;
using MarinosV2PrototypeShared.Utils.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace MarinosV2PrototypeShared.Utils;

public class EntityContractResolver : DefaultContractResolver
{
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        if (type == null)
            return CreateProperties(type, memberSerialization);
        while (type != null && type.Assembly != GetType().Assembly)
            type = type.BaseType;
        return base.CreateProperties(type, memberSerialization).Where(_ => !typeof(TrackedEntity).GetProperties().Select(__ => __.Name).Contains(_.PropertyName)).ToList();
    }
}