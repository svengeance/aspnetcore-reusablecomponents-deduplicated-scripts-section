using System;
using System.Linq;
using System.Runtime.Serialization;
using FastMember;

namespace ExampleProject.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns the hashcode of an object created by hashing each of its internal properties.
        /// This should result in objects with the same properties returning similar hashes.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int ValueHashCode(this object o)
        {
            if (o == null)
                throw new ArgumentNullException(nameof(o));

            unchecked
            {
                var accessor = TypeAccessor.Create(o.GetType(), false);
                var hash = 17;

                // https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-overriding-gethashcode
                foreach (var mem in accessor.GetMembers()
                                            .Where(w => w.GetAttribute(typeof(IgnoreDataMemberAttribute), true) == null))
                    hash = hash * 23 + (accessor[o, mem.Name]?.GetHashCode() ?? 0);

                return hash;
            }
        }
    }
}