using Newtonsoft.Json;
using ReactiveUI;

namespace MarinosV2PrototypeShared.BaseModels;

[JsonObject]
public abstract class ChangeEntity : IdEntity
{
    private DateTime _createDate;
    public DateTime CreateDate
    {
        get => _createDate;
        set => this.RaiseAndSetIfChanged(ref _createDate, value);
    }

    private DateTime _updateDate;
    public DateTime UpdateDate
    {
        get => _updateDate;
        set => this.RaiseAndSetIfChanged(ref _updateDate, value);
    }
}