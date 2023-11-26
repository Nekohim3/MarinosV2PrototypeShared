using MarinosV2PrototypeShared.BaseModels;
using System.Linq.Expressions;

namespace MarinosV2PrototypeShared.Utils.Extensions;

public static class TrackExtension
{
    public static List<T> StartTracking<T>(this List<T> tList) where T : TrackedEntity
    {
        foreach (var x in tList)
            x.StartTracking();

        return tList;
    }

    public static List<T> AcceptChanges<T>(this List<T> tList) where T : TrackedEntity
    {
        foreach (var x in tList)
            x.AcceptChanges();

        return tList;
    }

    public static List<T> RevertChanges<T>(this List<T> tList) where T : TrackedEntity
    {
        foreach (var x in tList)
            x.RevertChanges();

        return tList;
    }



    public static bool IsPropertyChanged<TEntity, TProperty>(this TEntity model, Expression<Func<TEntity, TProperty>> propertySelector) where TEntity : TrackedEntity =>
        model.IsPropertyChanged((propertySelector.Body as MemberExpression).Member.Name);
}