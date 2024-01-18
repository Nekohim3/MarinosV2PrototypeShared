using MarinosV2PrototypeShared.Utils.Attributes;
using Newtonsoft.Json;
using ReactiveUI;

namespace MarinosV2PrototypeShared.BaseModels;

[JsonObject]
public abstract class TreeEntity<T> : Entity where T : TreeEntity<T>
{
    protected Guid? _idParent;
    [TrackInclude]
    public Guid? IdParent
    {
        get => _idParent;
        set => this.RaiseAndSetIfChanged(ref _idParent, value);
    }

    protected T? _parent;
    [TrackInclude]
    public virtual T? Parent
    {
        get => _parent;
        set => this.RaiseAndSetIfChanged(ref _parent, value);
    }

    protected ICollection<T>? _childs;
    [TrackInclude]
    public virtual ICollection<T>? Childs
    {
        get => _childs;
        set => this.RaiseAndSetIfChanged(ref _childs, value);
    }

    public virtual void AddChild(T child)
    {
        Childs.Add(child);
        child.Parent = (T)this;
    }

    public virtual void AddChilds(IEnumerable<T> list)
    {
        foreach (var x in list)
            AddChild(x);
    }
}