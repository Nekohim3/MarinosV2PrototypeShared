using System.Linq.Expressions;
using MarinosV2PrototypeShared.BaseModels;

namespace MarinosV2PrototypeShared.Utils.Extensions
{
    public static class IncludeExtension
    {
        public static List<(TEntity, TProperty)> Include<TEntity, TProperty>(this ICollection<TEntity> source, Expression<Func<TEntity, TProperty>> nav) where TEntity : Entity
        {
            return null;
        }
    }
}
