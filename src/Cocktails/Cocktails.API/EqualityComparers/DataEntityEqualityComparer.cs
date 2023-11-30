using Cocktails.API.Models.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Cocktails.API.EqualityComparers
{
    public class DataEntityEqualityComparer : IEqualityComparer<IDataEntity>
    {
        public bool Equals(IDataEntity x, IDataEntity y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] IDataEntity obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
