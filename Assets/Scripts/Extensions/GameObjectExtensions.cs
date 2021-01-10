using UnityEngine;

namespace Game.Extensions {
    /// <summary>
    /// Extension methods for UnityEngine.GameObject.
    /// </summary>
    public static class GameObjectExtensions {
        /// <summary>
        /// Gets a component attached to the given game object.
        /// If one isn't found, a new one is attached and returned.
        /// </summary>
        /// <param name="gameObject">Game object.</param>
        /// <returns>Previously or newly attached component.</returns>
        /// <see cref="https://github.com/mminer/unity-extensions"/>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component {
            return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
        }

        /// <summary>
        /// Checks whether a game object has a component of type T attached.
        /// </summary>
        /// <param name="gameObject">Game object.</param>
        /// <returns>True when component is attached.</returns>
        /// <see cref="https://github.com/mminer/unity-extensions"/>
        public static bool HasComponent<T>(this GameObject gameObject) where T : Component {
            return gameObject.GetComponent<T>() != null;
        }
    }
}
