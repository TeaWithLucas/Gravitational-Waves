using UnityEngine;

namespace Game.Extensions {
    /// <summary>
    /// Extension methods for int.
    /// Sources: https://gist.github.com/omgwtfgames/f917ca28581761b8100f
    /// </summary>
    public static class IntExtensions {
        public static int WithRandomSign(this int value, float negativeProbability = 0.5f) {
            return Random.value < negativeProbability ? -value : value;
        }

    }
}