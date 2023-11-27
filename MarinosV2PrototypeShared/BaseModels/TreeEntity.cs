using Newtonsoft.Json;
using ReactiveUI;

namespace MarinosV2PrototypeShared.BaseModels;

[JsonObject]
public abstract class TreeEntity<T> : Entity where T : TreeEntity<T>
{
    private Guid? _idParent;
    public Guid? IdParent
    {
        get => _idParent;
        set => this.RaiseAndSetIfChanged(ref _idParent, value);
    }

    private T? _parent;
    public virtual T? Parent
    {
        get => _parent;
        set => this.RaiseAndSetIfChanged(ref _parent, value);
    }

    private ICollection<T> _childs;
    public virtual ICollection<T> Childs
    {
        get => _childs;
        protected set => this.RaiseAndSetIfChanged(ref _childs, value);
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