using Newtonsoft.Json;

namespace MarinosV2PrototypeShared.BaseModels;

[JsonObject]
public abstract class Entity : ChangeEntity
{
    public override bool Equals(object? o)
    {
        if (o is not ChangeEntity e)
            return false;
        return e.GetHashCode() == GetHashCode();
    }
}