using MarinosV2PrototypeShared.BaseModels;
using Newtonsoft.Json;
using ReactiveUI;

namespace MarinosV2PrototypeShared.Models;

[JsonObject]
public class SmsDocumentFile : Entity
{
    protected string _file;
    public string File
    {
        get => _file;
        set => this.RaiseAndSetIfChanged(ref _file, value);
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