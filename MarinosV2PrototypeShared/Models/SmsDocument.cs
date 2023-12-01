using MarinosV2PrototypeShared.BaseModels;
using Newtonsoft.Json;
using ReactiveUI;

namespace MarinosV2PrototypeShared.Models;

[JsonObject]
public class SmsDocument : Entity
{
    protected string _name = string.Empty;
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    protected string _number = string.Empty;
    public string Number
    {
        get => _number;
        set => this.RaiseAndSetIfChanged(ref _number, value);
    }

    protected Guid _idPartition;
    public Guid IdPartition
    {
        get => _idPartition;
        set => this.RaiseAndSetIfChanged(ref _idPartition, value);
    }

    protected SmsPartition? _partition;
    public virtual SmsPartition? Partition
    {
        get => _partition;
        set => this.RaiseAndSetIfChanged(ref _partition, value);
    }

    protected ICollection<SmsDocumentChange>? _documentChanges;
    public virtual ICollection<SmsDocumentChange>? DocumentChanges
    {
        get => _documentChanges;
        protected set => this.RaiseAndSetIfChanged(ref _documentChanges, value);
    }

    protected ICollection<SmsDocumentFile>? _documentFiles;
    public virtual ICollection<SmsDocumentFile>? DocumentFiles
    {
        get => _documentFiles;
        protected set => this.RaiseAndSetIfChanged(ref _documentFiles, value);
    }
}