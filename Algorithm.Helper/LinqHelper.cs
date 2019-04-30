using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Algorithm.Helper
{
    public static class LinqHelper
    {
        public static Expression<Func<TElement, bool>> BuildOrExpression<TElement, TValue>
            (Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values)
        {
            if (null == valueSelector)
                throw new ArgumentNullException("valueSelector");

            if (null == values)
                throw new ArgumentNullException("values");

            ParameterExpression p = valueSelector.Parameters.Single();

            if (!values.Any())
                return e => false;

            var equals = values.Select(value =>
                (Expression)Expression.Equal(
                     valueSelector.Body,
                     Expression.Constant(
                         value,
                         typeof(TValue)
                     )
                )
            );

            var body = equals.Aggregate<Expression>(
                     (accumulate, equal) => Expression.Or(accumulate, equal)
             );

            return Expression.Lambda<Func<TElement, bool>>(body, p);
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TResult> SelectWithPrevious<TSource, TResult>
            (this IEnumerable<TSource> source, Func<TSource, TSource, TResult> projection)
        {
            using (var iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    yield break;
                }
                TSource previous = iterator.Current;
                while (iterator.MoveNext())
                {
                    yield return projection(previous, iterator.Current);
                    previous = iterator.Current;
                }
            }
        }

        public static IEnumerable<TResult> SelectPrevious<TSource, TResult>
            (this IEnumerable<TSource> source, Func<TSource, TResult> projection)
        {
            using (var iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    yield break;
                }
                TSource previous = iterator.Current;
                while (iterator.MoveNext())
                {
                    yield return projection(previous);
                    previous = iterator.Current;
                }
            }
        }

        public static IEnumerable<Tuple<T, T>> Intermediate<T>(this IEnumerable<T> source)
        {
            using (var iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    yield break;
                }
                T previous = iterator.Current;
                while (iterator.MoveNext())
                {
                    yield return new Tuple<T, T>(previous, iterator.Current);
                    previous = iterator.Current;
                }
            }
        }

        public static int Next(this IEnumerable<int> source, int param1)
        {
            try
            {
                return source.SkipWhile(obj => obj != param1).Skip(1).First();
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}