using System.Collections.Generic;
using UnityEngine;

namespace Game.Extensions {
    /// <summary>
    /// Extension methods for UnityEngine.Vector3.
    /// </summary>
    public static class Vector3Extensions {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <see cref="https://gist.github.com/omgwtfgames/f917ca28581761b8100f"/>
        public static Vector3 WithX(this Vector3 v, float x) {
            return new Vector3(x, v.y, v.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <see cref="https://gist.github.com/omgwtfgames/f917ca28581761b8100f"/>
        public static Vector3 WithY(this Vector3 v, float y) {
            return new Vector3(v.x, y, v.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        /// <see cref="https://gist.github.com/omgwtfgames/f917ca28581761b8100f"/>
        public static Vector3 WithZ(this Vector3 v, float z) {
            return new Vector3(v.x, v.y, z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        /// <see cref="https://gist.github.com/omgwtfgames/f917ca28581761b8100f"/>
        public static Vector3 WithZ(this Vector2 v, float z) {
            return new Vector3(v.x, v.y, z);
        }

        /// <summary>
        /// Finds the position closest to the given one.
        /// </summary>
        /// <param name="position">World position.</param>
        /// <param name="otherPositions">Other world positions.</param>
        /// <returns>Closest position.</returns>
        /// <see cref="https://github.com/mminer/unity-extensions"/>
        public static Vector3 GetClosest(this Vector3 position, IEnumerable<Vector3> otherPositions) {
            var closest = Vector3.zero;
            var shortestDistance = Mathf.Infinity;

            foreach (var otherPosition in otherPositions) {
                var distance = (position - otherPosition).sqrMagnitude;

                if (distance < shortestDistance) {
                    closest = otherPosition;
                    shortestDistance = distance;
                }
            }

            return closest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axisDirection">unit vector in direction of an axis (eg, defines a line that passes through zero)</param>
        /// <param name="point">the point to find nearest on line for</param>
        /// <param name="isNormalized"></param>
        /// <returns></returns>
        /// <see cref="https://gist.github.com/omgwtfgames/f917ca28581761b8100f"/>
        public static Vector3 NearestPointOnAxis(this Vector3 axisDirection, Vector3 point, bool isNormalized = false) {
            if (!isNormalized) axisDirection.Normalize();
            var d = Vector3.Dot(point, axisDirection);
            return axisDirection * d;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineDirection">unit vector in direction of line</param>
        /// <param name="point">the point to find nearest on line for</param>
        /// <param name="pointOnLine">a point on the line (allowing us to define an actual line in space)</param>
        /// <param name="isNormalized"></param>
        /// <returns></returns>
        /// <see cref="https://gist.github.com/omgwtfgames/f917ca28581761b8100f"/>
        public static Vector3 NearestPointOnLine(
            this Vector3 lineDirection, Vector3 point, Vector3 pointOnLine, bool isNormalized = false) {
            if (!isNormalized) lineDirection.Normalize();
            var d = Vector3.Dot(point - pointOnLine, lineDirection);
            return pointOnLine + lineDirection * d;
        }
    }
}
