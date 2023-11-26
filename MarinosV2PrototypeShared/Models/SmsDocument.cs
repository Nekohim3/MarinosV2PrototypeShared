using MarinosV2PrototypeShared.BaseModels;
using Newtonsoft.Json;
using ReactiveUI;

namespace MarinosV2PrototypeShared.Models;

[JsonObject]
public class SmsDocument : Entity
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

    private Guid _idPartition;
    public Guid IdPartition
    {
        get => _idPartition;
        set => this.RaiseAndSetIfChanged(ref _idPartition, value);
    }

    private SmsPartition? _partition;
    public virtual SmsPartition? Partition
    {
        get => _partition;
        set => this.RaiseAndSetIfChanged(ref _partition, value);
    }

    private ICollection<SmsDocumentChange>? _documentChanges;
    public virtual ICollection<SmsDocumentChange>? DocumentChanges
    {
        get => _documentChanges;
        set => this.RaiseAndSetIfChanged(ref _documentChanges, value);
    }

    private ICollection<SmsDocumentFile>? _documentFiles;
    public virtual ICollection<SmsDocumentFile>? DocumentFiles
    {
        get => _documentFiles;
        set => this.RaiseAndSetIfChanged(ref _documentFiles, value);
    }
}