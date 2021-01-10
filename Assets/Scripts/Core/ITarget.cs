using UnityEngine;

namespace Game.Core {
    public interface ITarget {
        string Name { get; }
        GameObject gameObject { get; }
        Transform transform { get; }
    }
}