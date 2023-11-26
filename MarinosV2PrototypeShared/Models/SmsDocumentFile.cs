using MarinosV2PrototypeShared.BaseModels;
using Newtonsoft.Json;
using ReactiveUI;

namespace MarinosV2PrototypeShared.Models;

[JsonObject]
public class SmsDocumentFile : Entity
{
    private string _file;
    public string File
    {
        get => _file;
        set => this.RaiseAndSetIfChanged(ref _file, value);
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