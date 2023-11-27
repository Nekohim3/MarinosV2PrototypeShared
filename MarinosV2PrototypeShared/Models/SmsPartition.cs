using MarinosV2PrototypeShared.BaseModels;
using MarinosV2PrototypeShared.Utils.Attributes;
using Newtonsoft.Json;
using ReactiveUI;

namespace MarinosV2PrototypeShared.Models;

[JsonObject]
public class SmsPartition : TreeEntity<SmsPartition>
{
    private string _name = string.Empty;
    [TrackInclude]
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private string _number = string.Empty;
    [TrackInclude]
    public string Number
    {
        get => _number;
        set => this.RaiseAndSetIfChanged(ref _number, value);
    }

    private ICollection<SmsDocument>? _documents;
    [TrackInclude]
    public virtual ICollection<SmsDocument>? Documents
    {
        get => _documents;
        protected set => this.RaiseAndSetIfChanged(ref _documents, value);
    }
}