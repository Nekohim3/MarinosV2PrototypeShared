using MarinosV2PrototypeShared.BaseModels;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using ReactiveUI;

namespace MarinosV2PrototypeShared.Models;

[JsonObject]
public class SmsPartition : TreeEntity<SmsPartition>
{
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private string _number = string.Empty;
    public string Number
    {
        get => _number;
        set => this.RaiseAndSetIfChanged(ref _number, value);
    }

    private ICollection<SmsDocument>? _documents;
    public virtual ICollection<SmsDocument>? Documents
    {
        get => _documents;
        set => this.RaiseAndSetIfChanged(ref _documents, value);
    }
}