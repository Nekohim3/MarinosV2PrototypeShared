using Newtonsoft.Json;
using ReactiveUI;

namespace MarinosV2PrototypeShared.BaseModels;

[JsonObject]
public abstract class IdEntity : VersionEntity
{
    private Guid _id;
    public Guid Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    public static bool operator !=(IdEntity? a, IdEntity? b)
    {
        return !(a == b);
    }

    public static bool operator ==(IdEntity? a, IdEntity? b)
    {
        if (a is null && b is null)
            return true;
        if (a is null || b is null)
            return false;
        return a.Equals(b);
    }

    public override bool Equals(object? o)
    {
        if (o is not IdEntity e)
            return false;
        if (e.Id                   == Guid.Empty && Id == Guid.Empty)
            return e.GetHashCode() == GetHashCode();
        return e.Id == Id;
    }
}