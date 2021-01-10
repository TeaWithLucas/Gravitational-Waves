using Game.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Game.Managers.SettingsManager;

namespace Game.UI.Templates {
    public class UITab : MonoBehaviour {

        public string Label { get; protected set; }

        public bool Active {
            get { return gameObject.activeSelf; }
            set { if (gameObject.activeSelf != value) gameObject.SetActive(value); }
        }

        public bool Ready { get; protected set; }
        public UIButton Button { get; protected set; }

        void OnEnable() {
            if (!Ready) {
                Construct();
                Ready = true;
            }

        }

        protected void Construct() {
            //Debug.LogFormat("Constructing {0}", this);
            UIFunctions.AddLayout(gameObject, UIFunctions.Layouts.Vertical);
            UIFunctions.SetPadding(gameObject, UIFunctions.Padding.Spacing);
            Label = name;
        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        internal void Destroy() {
            Destroy(gameObject);
        }

        internal void SetLabel(string label) {
            Label = label;
        }

        internal UIButton CreateTabButton(GameObject parent, UnityAction<UITab> callback) {
            Button = UITemplates.CreateButton(string.Format("{0} Button", name), parent, Label);
            UIFunctions.AddLayoutElement(Button.gameObject, new Vector2(200, -1));
            Button.SetOnClickListener(delegate { callback.Invoke(this); });
            return Button;
        }
    }
}