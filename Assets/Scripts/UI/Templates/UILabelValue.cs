using UnityEngine;
using System.Collections;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using static Game.Managers.SettingsManager;
using System.Linq;
using System.Collections.Generic;
using Game.UI;

namespace Game.UI.Templates {
    public class UILabelValue : MonoBehaviour, IUILabel {
        public TextMeshProUGUI Label { get; set; }
        public LayoutElement LabelLayout { get; set; }
        public TextMeshProUGUI Value { get; set; }
        public LayoutElement ValueLayout { get; set; }

        public bool Ready { get; protected set; }
        [SerializeField]
        private string m_defaultLabel = "Label";
        [SerializeField]
        private string m_defaultValue = "Value";
        [SerializeField]
        private List<string> m_labelFormats = new List<string>() { TMPColour.Black };
        [SerializeField]
        private List<string> m_valueFormats = new List<string>() { TMPColour.Black };


        private void OnEnable() {
            if (!Ready) {
                Construct();

                Ready = true;
            }
        }
        protected void Construct() {
            UIFunctions.AddLayout(gameObject, UIFunctions.Layouts.Horizontal);

            Label = UITemplates.CreateTextLabel("Label", gameObject, m_defaultLabel);
            LabelLayout = Label.gameObject.AddComponent<LayoutElement>();
            LabelLayout.minWidth = 50;
            LabelLayout.flexibleWidth = 100;

            Value = UITemplates.CreateTextValue("Value", gameObject, m_defaultValue);
            ValueLayout = Value.gameObject.AddComponent<LayoutElement>();
            ValueLayout.minWidth = 20;
            ValueLayout.preferredWidth = 40;

            SetLabel(m_defaultLabel);
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void SetLabel(object obj) {
            string text = obj == null ? "" : obj.ToString();
            Label.text = string.Format("{0}{1}", Formatting(), text);
        }

        public string Formatting() {
            return m_labelFormats.Aggregate((a, b) => a + b);
        }
        public void SetValue(object obj) {
            string text = obj == null ? "" : obj.ToString();
            Value.text = string.Format("{0}{1}", ValueFormatting(), text);
        }

        public string ValueFormatting() {
            return m_valueFormats.Aggregate((a, b) => a + b);
        }

        public void SetLayout(int labelMinWidth, int labelPrefWidth, int fieldMinWidth, int fieldPrefWidth) {
            LabelLayout.minWidth = labelMinWidth;
            LabelLayout.preferredWidth = labelPrefWidth;
            ValueLayout.minWidth = fieldMinWidth;
            ValueLayout.preferredWidth = fieldPrefWidth;
        }
        public void Destroy() {
            Destroy(gameObject);
        }
    }
}