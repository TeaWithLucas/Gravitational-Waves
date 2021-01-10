using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Game.Extensions {
    /// <summary>
    /// Extension methods for System.Collections.Generic.IList
    /// Sources: https://gist.github.com/omgwtfgames/f917ca28581761b8100f, https://stackoverflow.com/a/1262619/1954875
    /// </summary>
    public static class IListExtensions {

        private static RNGCryptoServiceProvider RNGCrypto = new RNGCryptoServiceProvider();

        /// <summary>
        /// Shuffle the list in place using the Fisher-Yates method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="fisherYates"></param>
        public static void Shuffle<T>(this IList<T> list, bool fisherYates = false) {
            if (fisherYates) {
                int n = list.Count;
                while (n > 1) {
                    n--;
                    int k = UnityEngine.Random.Range(0, n + 1);
                    T value = list[k];
                    list[k] = list[n];
                    list[n] = value;
                }
            } else {
                int n = list.Count;
                while (n > 1) {
                    byte[] box = new byte[1];
                    do RNGCrypto.GetBytes(box);
                    while (!(box[0] < n * (byte.MaxValue / n)));
                    int k = box[0] % n;
                    n--;
                    T value = list[k];
                    list[k] = list[n];
                    list[n] = value;
                }
            }
        }

        /// <summary>
        /// Return a random item from the list.
        /// Sampling with replacement.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RandomItem<T>(this IList<T> list) {
            if (list.Count == 0) throw new IndexOutOfRangeException("Cannot select a random item from an empty list");
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Removes a random item from the list, returning that item.
        /// Sampling without replacement.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RemoveRandom<T>(this IList<T> list) {
            if (list.Count == 0) throw new IndexOutOfRangeException("Cannot remove a random item from an empty list");
            int index = UnityEngine.Random.Range(0, list.Count);
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }
    }
}