using UnityEngine;

namespace Game.Extensions {
    /// <summary>
    /// Extension methods for float.
    /// </summary>
    public static class FloatExtensions {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueRangeMin"></param>
        /// <param name="valueRangeMax"></param>
        /// <param name="newRangeMin"></param>
        /// <param name="newRangeMax"></param>
        /// <returns></returns>
        /// <see cref="https://gist.github.com/omgwtfgames/f917ca28581761b8100f"/>
        public static float LinearRemap(this float value,
                                         float valueRangeMin, float valueRangeMax,
                                         float newRangeMin, float newRangeMax) {
            return (value - valueRangeMin) / (valueRangeMax - valueRangeMin) * (newRangeMax - newRangeMin) + newRangeMin;
        }

    }
}