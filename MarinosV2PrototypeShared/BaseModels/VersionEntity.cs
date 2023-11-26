using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace MarinosV2PrototypeShared.BaseModels;

[JsonObject]
public abstract class VersionEntity : TrackedEntity
{
    private uint _version;
    [Timestamp]
    public uint Version
    {
        get => _version;
        set => this.RaiseAndSetIfChanged(ref _version, value);
    }
}