using Cocktails.API.EqualityComparers;
using Cocktails.API.Models.Interfaces;

namespace Cocktails.API.Extensions
{
    public static class RelationExtensions
    {
        public static void SetRelations<T>(this ICollection<T> relations, ICollection<T> newRelations) where T : IDataEntity
        {
            var toRemoveEntities = relations
                .Except(newRelations, (IEqualityComparer<T>)new DataEntityEqualityComparer())
                .ToList();

            var toAddEntities = newRelations
                .Except(relations, (IEqualityComparer<T>)new DataEntityEqualityComparer())
                .ToList();

            foreach ( var entity in toRemoveEntities )
            {
                relations.Remove( entity );
            }

            foreach ( var entity in toAddEntities )
            {
                relations.Add( entity );
            }
        }
    }
}
