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
        //foreach (var x in sender.GetProperties().Where(_ => Attribute.IsDefined(_, typeof(TrackInclude))))
        while (type != null && type.Assembly != GetType().Assembly)
            type = type.BaseType;
        //return base.CreateProperties(type, memberSerialization).Where(_ => !typeof(TrackedEntity).GetProperties().Select(__ => __.Name).Contains(_.PropertyName)).ToList();
        //if (type.Name.StartsWith("UI_"))
        //    type = type.BaseType!;
        var q = base.CreateProperties(type, memberSerialization);
        return base.CreateProperties(type, memberSerialization).Where(_ => !typeof(TrackedEntity).GetProperties().Select(__ => __.Name).Contains(_.PropertyName)).ToList();
    }
}