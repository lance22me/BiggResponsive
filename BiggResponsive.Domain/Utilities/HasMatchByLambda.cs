using System;
using System.Collections;
using System.Collections.Generic;

namespace BiggResponsive.Domain.Utilities
{
    public class HasMatchByLambda<T> : IEnumerable<T>
    {
        private Func<T, T, Boolean> comparison;
        private IEnumerable<T> orig;

        public HasMatchByLambda(Func<T, T, bool> comparer, IEnumerable<T> source)
        {
            comparison = comparer;
            orig = source;
        }

        /// <summary>
        /// If there is a match, it will return a populated collection
        /// IMPORTANT - the Extension method has returning true or false
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            List<T> noMatch = new List<T>();
            List<T> hasMatch = new List<T>();

            foreach (T element in orig)
            {
                if (!noMatch.Exists(el => comparison(el, element)))
                {
                    noMatch.Add(element);
                }
                else
                {
                    hasMatch.Add(element);
                    yield return element;
                    break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
