using System;
using System.Collections;
using System.Collections.Generic;

namespace BiggResponsive.Domain.Utilities
{
    public class DistinctByLambda<T> : IEnumerable<T>
    {
        private Func<T, T, Boolean> comparison;
        private IEnumerable<T> orig;

        public DistinctByLambda(Func<T, T, bool> comparer, IEnumerable<T> source)
        {
            comparison = comparer;
            orig = source;
        }

        /// <summary>
        /// Provides the comparison mechanism for the field that we need to be unique.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            List<T> alreadyFound = new List<T>();

            foreach (T element in orig)
            {
                if (!alreadyFound.Exists(el => comparison(el, element)))
                {
                    alreadyFound.Add(element);
                    yield return element;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}