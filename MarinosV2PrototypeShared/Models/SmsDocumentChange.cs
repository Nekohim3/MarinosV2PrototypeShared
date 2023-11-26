using MarinosV2PrototypeShared.BaseModels;
using Newtonsoft.Json;
using ReactiveUI;

namespace MarinosV2PrototypeShared.Models;

[JsonObject]
public class SmsDocumentChange : Entity
{
    private string _documentVersion = string.Empty;
    public string DocumentVersion
    {
        get => _documentVersion;
        set => this.RaiseAndSetIfChanged(ref _documentVersion, value);
    }

    private DateTime _documentVersionDate;
    public DateTime DocumentVersionDate
    {
        get => _documentVersionDate;
        set => this.RaiseAndSetIfChanged(ref _documentVersionDate, value);
    }

    private string _description = string.Empty;
    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    private Guid _idDocument;
    public Guid IdDocument
    {
        get => _idDocument;
        set => this.RaiseAndSetIfChanged(ref _idDocument, value);
    }

    private SmsDocument? _document;
    public virtual SmsDocument? Document
    {
        get => _document;
        set => this.RaiseAndSetIfChanged(ref _document, value);
    }
}