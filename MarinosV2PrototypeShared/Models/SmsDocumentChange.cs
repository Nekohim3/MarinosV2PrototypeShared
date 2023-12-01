using MarinosV2PrototypeShared.BaseModels;
using Newtonsoft.Json;
using ReactiveUI;

namespace MarinosV2PrototypeShared.Models;

[JsonObject]
public class SmsDocumentChange : Entity
{
    protected string _documentVersion = string.Empty;
    public string DocumentVersion
    {
        get => _documentVersion;
        set => this.RaiseAndSetIfChanged(ref _documentVersion, value);
    }

    protected DateTime _documentVersionDate;
    public DateTime DocumentVersionDate
    {
        get => _documentVersionDate;
        set => this.RaiseAndSetIfChanged(ref _documentVersionDate, value);
    }

    protected string _description = string.Empty;
    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    protected Guid _idDocument;
    public Guid IdDocument
    {
        get => _idDocument;
        set => this.RaiseAndSetIfChanged(ref _idDocument, value);
    }

    protected SmsDocument? _document;
    public virtual SmsDocument? Document
    {
        get => _document;
        set => this.RaiseAndSetIfChanged(ref _document, value);
    }
}