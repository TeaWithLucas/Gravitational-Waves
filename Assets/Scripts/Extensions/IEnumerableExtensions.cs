using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Game.Extensions {
    /// <summary>
    /// Extension methods for System.Collections.Generic.IEnumerable
    /// </summary>
    public static class IEnumerableExtensions {
        private static readonly Dictionary<string, string> m_and = new Dictionary<string, string> { { "albanian", "dhe" }, { "basque", "eta" }, { "belarusian", "і" }, { "bosnian", "i" }, { "bulgarian", "и" }, { "catalan", "i" }, { "croatian", "i" }, { "czech", "a" }, { "danish", "og" }, { "dutch", "en" }, { "estonian", "ja" }, { "english", "and" }, { "finnish", "ja" }, { "french", "et" }, { "galician", "e" }, { "german", "und" }, { "greek", "και" }, { "hungarian", "és" }, { "icelandic", "og" }, { "irish", "agus" }, { "italian", "e" }, { "latvian", "un" }, { "lithuanian", "ir" }, { "macedonian", "и" }, { "maltese", "u" }, { "norwegian", "og" }, { "polish", "i" }, { "portuguese", "e" }, { "romanian", "și" }, { "russian", "а также" }, { "serbian", "и" }, { "slovak", "a" }, { "slovenian", "in" }, { "spanish", "y" }, { "swedish", "och" }, { "ukrainian", "і" }, { "welsh", "ac" }, { "yiddish", "און" } };

        /// <summary>
        /// IEnumerable<string> to Natural Language list using commas and 'and'.
        /// Based upon CodesInChaos code, retrieved 02/03/2020, 
        /// </summary>
        /// <param name="sequence">The sequence of strings to be Naturalised</param>
        /// <returns>Natural Language list as a string</returns>
        /// <see cref="https://stackoverflow.com/a/4239913/1954875"/>
        public static string Commaise(this IEnumerable sequence, string lang = "english") {
            IList<string> list = new List<string>(sequence.Cast<string>());
            string langLower = lang.ToLower();
            string and = m_and.ContainsKey(langLower) ? m_and[langLower] : m_and["english"];
            if (list == null || list.Count == 0) {
                return "";
            } else if (list.Count == 1) {
                return list.First();
            } else {
                return string.Format("{0} {1} {2}", string.Join(", ", list.Take(list.Count - 1).ToArray()), and, list.Last());
            }
        }
    }
}