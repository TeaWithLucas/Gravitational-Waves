using UnityEngine;

namespace Game.UI.Templates {
    public interface IUIImage {
        void SetImage(bool enabled);
        void SetImage(Sprite sprite);
    }
}