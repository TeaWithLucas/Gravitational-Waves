using UnityEngine;
using System.Collections;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using static Game.Managers.SettingsManager;
using System.Linq;
using System.Collections.Generic;
using Game.Extensions;

namespace Game.UI.Templates {
    [RequireComponent(typeof(Button))]
    public class UIButton : MonoBehaviour, IUIButton, IUILabel, IUIImage {
        public Button Button { get; set; }
        public TextMeshProUGUI Label { get; set; }
        protected UnityAction onClick { get; set; }
        public bool IsToggle { get; protected set; }
        public bool Toggled { get; protected set; }
        public bool Interactable {
            get { return Button.interactable; }
            set { if (Button.interactable != value) Button.interactable = value; }
        }
        public bool Active {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }

        public bool Ready { get; protected set; }

        [SerializeField]
        private static string m_defaultLabel = "Button";
        [SerializeField]
        private List<string> m_labelFormats = new List<string>() { TMPColour.Black };
        [SerializeField]
        private Color m_toggleColor = new Color(0.2f, 0.2f, 0.2f);

        void OnEnable() {
            if (!Ready) {
                Construct();
                Ready = true;
            }
        }

        protected void Construct() {
            UIFunctions.SetRectAnchors(gameObject);
            Button = gameObject.GetComponent<Button>();
            Button.onClick.AddListener(OnClick);
            UIFunctions.AddLayout(Button.gameObject, UIFunctions.Layouts.Horizontal);
            Label = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            SetLabel(m_defaultLabel);
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void AddOnClickListener(UnityAction function) {
            onClick += function;
        }

        public void SetOnClickListener(UnityAction function) {
            onClick = function;
        }

        public void SetOnClickListenerInvoke(UnityAction<IUIButton> function) {
            onClick = delegate { function?.Invoke(this); };
        }

        public void SetLabel(object label) {
            string text = label == null ? "" : label.ToString();
            Label.text = string.Format("{0}{1}", Formatting(), text);
        }

        public void SetButtonColor(Color color) {
            Button.image.color = color;
        }
        public void SetButtonColor(int r, int g, int b) {
            SetButtonColor(r, g, b, 255);
        }
        public void SetButtonColor(int r, int g, int b, int a) {
            SetButtonColor((float)r / 255, (float)g / 255, (float)b / 255, (float)a / 255);
        }
        public void SetButtonColor(float r, float g, float b) {
            SetButtonColor(r, g, b, 1);
        }
        public void SetButtonColor(float r, float g, float b, float a) {
            Button.image.color = new Color(r, g, b, a);
        }
        public void SetImage(Sprite sprite) {
            Button.image.sprite = sprite;
        }
        public void SetImage(bool enabled) {
            Button.image.enabled = enabled;
        }
        public void ButtonToggle(bool enabled) {
            IsToggle = enabled;
        }
        public string Formatting() {
            return m_labelFormats.Aggregate((a, b) => a + b);
        }
        public void Destroy() {
            Destroy(gameObject);
        }
        protected void OnClick() {
            Toggle();
            Debug.LogFormat("Button Invokes: {0}", onClick.GetInvocationList().Select(x => x.ToString()).Commaise());
            onClick?.Invoke();
            if (onClick == null) {
                Debug.LogWarningFormat("Missing Button {0}", name);
            }
        }
        protected void Toggle() {
            if (IsToggle) {
                if (Toggled) {
                    Button.image.color += m_toggleColor;
                } else {
                    Button.image.color -= m_toggleColor;
                }
                Toggled = !Toggled;
            }
        }
    }
}