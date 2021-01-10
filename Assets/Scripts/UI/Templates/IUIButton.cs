using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI.Templates {
    public interface IUIButton {
        Button Button { get; }
        bool Toggled { get; }
        bool Interactable { get; set; }
        bool Active { get; set; }
        bool Ready { get; }
        bool IsToggle { get; }

        void AddOnClickListener(UnityAction function);
        void SetOnClickListener(UnityAction function);
        void SetOnClickListenerInvoke(UnityAction<IUIButton> function);
        void Destroy();
        void SetButtonColor(Color color);
        void SetButtonColor(int r, int g, int b, int a);
        void SetButtonColor(float r, float g, float b);
        void SetButtonColor(float r, float g, float b, float a);
        void SetImage(Sprite sprite);
        void SetImage(bool enabled);
        void ButtonToggle(bool enabled);
    }
}