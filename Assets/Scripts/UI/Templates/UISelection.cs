using Game.Core;
using Game.Managers;
using Game.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI.Templates {
    public class UISelection : MonoBehaviour, IUIButton {

        public UISelector UISelector { get; protected set; }
        public LayoutElement SelectionLayout { get; protected set; }
        public Button Button { get; protected set; }
        protected UnityAction onClick { get; set; }
        public bool IsToggle { get; protected set; }
        public bool Toggled { get; protected set; }

        public IChoice Choice { get; protected set; }

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
        private Color m_toggleColor = new Color(0.3f, 0.3f, 0.3f);

        void OnEnable() {
            if (!Ready) {
                Construct();
                Ready = true;
            }

        }

        protected virtual void Construct() {
            //Debug.LogFormat("Constructing {0}", this);
            SelectionLayout = UIFunctions.AddLayoutElement(gameObject, new Vector2(-1, 100), new Vector2(-1, 150));
            Button = UIFunctions.AddButton(gameObject);
            Button.onClick.AddListener(OnClick);
            if (Button.image != null) {
                Button.image.color = SettingsManager.ButtonColorStandard;
            }

        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        internal void Create(IChoice choice) {
            Choice = choice;
            UISelector = GetComponentInParent<UISelector>();

            Refresh();
        }

        public void AddOnClickListener(UnityAction function) {
            onClick += function;
        }

        public void SetOnClickListener(UnityAction function) {
            onClick = function;
        }

        public void AddOnClickListenerInvoke(UnityAction<IUIButton> function) {
            onClick += delegate { function?.Invoke(this); };
        }

        public void SetOnClickListenerInvoke(UnityAction<IUIButton> function) {
            onClick = delegate { function?.Invoke(this); };
        }

        public virtual void Refresh() {
            if (Ready && Choice != null) {
                //Debug.LogFormat("{0} Refreshed", this);
            } else if (!Ready) {
                Debug.LogFormat("{0} called before ready", name);
            } else {
                Debug.LogFormat("{0}'s choice note set yet", name);
            }
        }

        protected void OnClick() {
            onClick?.Invoke();
        }

        public void ReplaceChoice(IChoice choice) {
            Choice = choice;
            Refresh();
        }

        public void Destroy() {
            Destroy(gameObject);
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
            if (Button.image != null) {
                if (Toggled) {
                    Button.image.color += m_toggleColor;
                }
                if (enabled) {
                    Button.image.color -= m_toggleColor;
                }
                Toggled = enabled;
            }

        }
    }
}