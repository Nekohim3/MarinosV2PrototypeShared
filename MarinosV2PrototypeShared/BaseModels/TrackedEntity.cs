using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using MarinosV2PrototypeShared.Utils;
using MarinosV2PrototypeShared.Utils.Attributes;
using MarinosV2PrototypeShared.Utils.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReactiveUI;

namespace MarinosV2PrototypeShared.BaseModels;

public abstract class TrackedEntity : ReactiveObject
{
    private                         Dictionary<string, object?> _baseValues = new();
    private                         Dictionary<string, object?> _baseValuesCollection = new();
    [JsonIgnore, NotMapped] private bool?                       _isChanged;
    [JsonIgnore, NotMapped]
    public bool? IsChanged
    {
        get
        {
            if (_isChanged == false)
            {
                foreach (var x in this.GetPropertiesCollections().Where(_ => Attribute.IsDefined(_, typeof(TrackInclude))).ToList())
                {
                    var old      = (_baseValuesCollection[x.Name] as IEnumerable).OfType<TrackedEntity>().ToList();
                    var newValue = (x.GetValue(this) as ICollection).OfType<TrackedEntity>().ToList();
                    if (old.Count != newValue.Count)
                    {
                        _isChanged = true;
                        return true;
                    }
                    else
                    {
                        for (var i = 0; i < old.Count; i++)
                        {
                            if (old[i] != newValue[i])
                            {
                                _isChanged = true;
                                return true;
                            }
                        }
                    }
                }
            }
            return _isChanged;
        }
        set => _isChanged = value;
    }

    public bool IsPropertyChanged(string propertyName) => _baseValues.ContainsKey(propertyName)
                                                              ? _baseValues[propertyName] != GetType().GetProperty(propertyName).GetValue(this)
                                                              : throw new Exception("Property is not tracked.");
    
    public void StartTracking()
    {
        if (!IsChanged.HasValue)
        {
            PropertyChanged += (sender, args) =>
                               {
                                   if (!IsChanged.HasValue)
                                       return;
                                   if (string.IsNullOrEmpty(args.PropertyName) || sender == null)
                                       return;
                                   if (sender.GetProperties().Count(_ => Attribute.IsDefined(_, typeof(TrackInclude)) && _.Name == args.PropertyName) != 0)
                                   {
                                       var newValue = sender.GetType().GetProperty(args.PropertyName).GetValue(sender);
                                       if (_baseValues[args.PropertyName] == newValue)
                                       {
                                           IsChanged = false;
                                           foreach (var x in sender.GetProperties().Where(_ => Attribute.IsDefined(_, typeof(TrackInclude))))
                                           {
                                               if (x.Name == args.PropertyName)
                                                   continue;
                                               if (_baseValues[x.Name] == null)
                                               {
                                                   if (x.GetValue(sender) != null)
                                                       IsChanged = true;
                                               }
                                               else
                                               {
                                                   if (_baseValues[x.Name].Equals(x.GetValue(sender)))
                                                       IsChanged = true;
                                               }
                                           }
                                       }
                                       else
                                       {
                                           IsChanged = true;
                                       }
                                   }
                               };
        }

        _baseValues.Clear();
        _baseValuesCollection.Clear();

        foreach (var x in this.GetPropertiesCollections().Where(_ => Attribute.IsDefined(_, typeof(TrackInclude))))
            _baseValuesCollection[x.Name] = (x.GetValue(this) as ICollection).OfType<TrackedEntity>().ToList();

        foreach (var x in this.GetProperties().Where(_ => Attribute.IsDefined(_, typeof(TrackInclude))))
            _baseValues[x.Name] = x.GetValue(this);

        IsChanged = false;
    }

    public void AcceptChanges()
    {
        if (!IsChanged.HasValue)
            throw new InvalidOperationException("Entity is not tracked.");

        _baseValues.Clear();
        _baseValuesCollection.Clear();

        foreach (var x in this.GetPropertiesCollections().Where(_ => Attribute.IsDefined(_, typeof(TrackInclude))))
            _baseValuesCollection[x.Name] = (x.GetValue(this) as ICollection).OfType<TrackedEntity>().ToList();

        foreach (var x in this.GetProperties().Where(_ => Attribute.IsDefined(_, typeof(TrackInclude))))
            _baseValues[x.Name] = x.GetValue(this);

        IsChanged = false;
    }

    /// <summary>
    /// todo: Откат списков не работает, хз как сделать
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public void RevertChanges(bool acceptLists = true)
    {
        if (!IsChanged.HasValue)
            throw new InvalidOperationException("Entity is not tracked.");
        foreach (var x in this.GetProperties().Where(_ => Attribute.IsDefined(_, typeof(TrackInclude))))
            x.SetValue(this, _baseValues[x.Name]);
        if (acceptLists)
        {
            _baseValuesCollection.Clear();

            foreach (var x in this.GetPropertiesCollections().Where(_ => Attribute.IsDefined(_, typeof(TrackInclude))))
                _baseValuesCollection[x.Name] = (x.GetValue(this) as ICollection).OfType<TrackedEntity>().ToList();
        }
        //foreach (var x in this.GetPropertiesCollections().Where(_ => Attribute.IsDefined(_, typeof(TrackInclude))))
        //    x.SetValue(this, _baseValuesCollection[x.Name]);

        IsChanged = false;
    }
}