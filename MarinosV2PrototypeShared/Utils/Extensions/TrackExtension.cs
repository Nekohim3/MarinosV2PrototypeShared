using MarinosV2PrototypeShared.BaseModels;
using System.Linq.Expressions;

namespace MarinosV2PrototypeShared.Utils.Extensions;

public static class TrackExtension
{
    public static List<T> StartTrackEx<T>(this List<T> tList) where T : TrackedEntity
    {
        foreach (var x in tList)
            x.StartTracking();

        return tList;
    }

    public static List<T> AcceptChangesEx<T>(this List<T> tList) where T : TrackedEntity
    {
        foreach (var x in tList)
            x.AcceptChanges();

        return tList;
    }

    public static List<T> RevertChangesEx<T>(this List<T> tList) where T : TrackedEntity
    {
        foreach (var x in tList)
            x.RevertChanges();

        return tList;
    }

    public static T StartTrackingEx<T>(this T t) where T : TrackedEntity
    {
        t.StartTracking();
        return t;
    }

    public static T AcceptChangesEx<T>(this T t) where T : TrackedEntity
    {
        t.AcceptChanges();
        return t;
    }

    public static T RevertChangesEx<T>(this T t) where T : TrackedEntity
    {
        t.RevertChanges();
        return t;
    }



    public static bool IsPropertyChanged<TEntity, TProperty>(this TEntity model, Expression<Func<TEntity, TProperty>> propertySelector) where TEntity : TrackedEntity =>
        model.IsPropertyChanged((propertySelector.Body as MemberExpression).Member.Name);
}