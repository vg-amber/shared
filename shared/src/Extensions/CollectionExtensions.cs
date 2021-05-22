using System;
using System.Collections.Generic;
using System.Linq;

namespace Amber.Shared.Extensions {
    /// <summary>
    /// Extensions for C# collections
    /// </summary>
    public static class CollectionExtensions {
        /// <summary>
        /// Apply the action on all elements of the given enumerable
        /// </summary>
        /// <param name="source">Enumerable</param>
        /// <param name="action">Action to apply</param>
        /// <typeparam name="T">Enumerable's element type</typeparam>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var item in source) {
                action(item);
            }
        }

        /// <summary>
        /// Filter non-null elements in the given enumerable
        /// </summary>
        /// <param name="source">Enumerable</param>
        /// <typeparam name="T">Enumerable's element type</typeparam>
        /// <returns>Enumerable without null elements</returns>
        public static IEnumerable<T> NonNull<T>(this IEnumerable<T?> source) where T : class => source.Where(e => e != null)!;

        /// <summary>
        /// Filter non-null elements in the given enumerable
        /// </summary>
        /// <param name="source">Enumerable</param>
        /// <typeparam name="T">Enumerable's element type</typeparam>
        /// <returns>Enumerable without null elements</returns>
        public static IEnumerable<T> NonNull<T>(this IEnumerable<T?> source) where T : struct => source.OfType<T>();

        /// <summary>
        /// Test whether the given array is empty
        /// </summary>
        /// <param name="source">Array</param>
        /// <typeparam name="T">Array's element type</typeparam>
        /// <returns>true if the array is empty, false otherwise</returns>
        public static bool IsEmpty<T>(this T[] source) => source.Length == 0;

        /// <summary>
        /// Test whether the given collection is empty
        /// </summary>
        /// <param name="source">Collection</param>
        /// <typeparam name="T">Collection's element type</typeparam>
        /// <returns>true if the collection is empty, false otherwise</returns>
        public static bool IsEmpty<T>(this IReadOnlyCollection<T> source) => source.Count == 0;

        /// <summary>
        /// Remove the first node matching the predicate in the given linked list
        /// </summary>
        /// <param name="list">Linked list</param>
        /// <param name="predicate">Predicate</param>
        /// <typeparam name="T">Linked list's element type</typeparam>
        /// <returns>Removed node or null</returns>
        public static LinkedListNode<T>? RemoveFirst<T>(this LinkedList<T> list, Predicate<T> predicate) {
            var node = list.First;
            while (node != null) {
                if (predicate(node.Value)) {    
                    list.Remove(node);
                    return node;
                }

                node = node.Next;
            }

            return null;
        }
    }
}