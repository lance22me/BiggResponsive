using System;
using System.Collections.Generic;
using System.Linq;
using BiggResponsive.Domain.Utilities;

namespace BiggResponsive.Domain.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Cuz .ToList() does bad things sometimes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns></returns>
        public static List<T> ToSafeList<T>(this IEnumerable<T> enumerable)
        {
            if (ReferenceEquals(null, enumerable))
            {
                return new List<T>();
            }
            return enumerable.ToList();
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, T, Boolean> comparer)
        {
            return new DistinctByLambda<T>(comparer, source);
        }

        public static IEnumerable<T> Match<T>(this IEnumerable<T> source, Func<T, T, Boolean> comparer)
        {
            return new HasMatchByLambda<T>(comparer, source).ToList();
        }

        public static bool HasMatch<T>(this IEnumerable<T> source, Func<T, T, Boolean> comparer)
        {
            var matchingContents = new HasMatchByLambda<T>(comparer, source).ToList();

            if (matchingContents.Count > 0)
            {
                return true;
            }

            return false;
        }

    }
}
