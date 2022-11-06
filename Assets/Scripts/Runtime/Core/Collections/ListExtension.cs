using System;
using System.Collections.Generic;

namespace SiriusFuture.Quiz.Core.Collections
{
    public static class ListExtension
    {
        private static readonly Random Random = new();

        public static void Shuffle<T>(this IList<T> list)
        {
            for (var i = list.Count; i > 0; i--)
            {
                var index = i - 1;
                var newIndex = Random.Next(index + 1);
                (list[newIndex], list[index]) = (list[index], list[newIndex]);
            }
        }
    }
}