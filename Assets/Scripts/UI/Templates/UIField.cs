using UnityEngine;
using System.Collections;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;
using System.Collections.Generic;
using static Game.Managers.SettingsManager;
using static Game.UI.UIFunctions;
using static Game.UI.UITemplates;
using Game.Core;

namespace Game.UI.Templates {
    public class UIField : MonoBehaviour, IUILabel {
        public LayoutGroup Layout { get; protected set; }
        public GameObject FieldPanel { get; protected set; }
        public TextMeshProUGUI Label { get; protected set; }
        public LayoutElement LabelLayout { get; protected set; }
        public TMP_InputField Field { get; protected set; }
        public LayoutElement FieldLayout { get; protected set; }
        public TextMeshProUGUI Description { get; protected set; }
        public LayoutElement DescriptionLayout { get; protected set; }
        public TextMeshProUGUI Placeholder { get; protected set; }
        public UnityAction<UIField> OnValidate { get; protected set; }
        public UnityEvent OnRefreshOptions { get; protected set; }

        public IChoice FieldChoice { get; protected set; }
        public string Value {
            get {
                return Field.text;
            }
            set {
                Field.text = value;
            }
        }

        public bool Ready { get; protected set; }


        [SerializeField]
        private string m_defaultLabel = "Label";
        [SerializeField]
        private string m_defaultDesc = "Description";
        [SerializeField]
        private List<string> m_labelFormats = new List<string>() { TMPColour.Black };
        [SerializeField]
        private List<string> m_descFormats = new List<string>() { TMPColour.Black };

        private void OnEnable() {
            if (!Ready) {
                Construct();
                Ready = true;
                SetLabel(m_defaultLabel);
            }
        }
        protected void Construct() {
            OnRefreshOptions = new UnityEvent();

            Layout = AddLayout(gameObject, Layouts.Vertical);

            Description = CreateTextLabel("Description", gameObject, m_defaultDesc);
            DescriptionLayout = Description.gameObject.AddComponent<LayoutElement>();
            Description.gameObject.SetActive(false);

            FieldPanel = CreatePanel("Field Panel", gameObject, false, Layouts.Horizontal);

            Label = CreateTextLabel("Label", FieldPanel, m_defaultLabel);
            LabelLayout = Label.gameObject.AddComponent<LayoutElement>();
            LabelLayout.minWidth = 100;

            Field = CreateInputField("Field", FieldPanel);
            FieldLayout = Field.gameObject.AddComponent<LayoutElement>();
            FieldLayout.preferredWidth = 500;

            Field.onDeselect.AddListener(delegate { OnValidate?.Invoke(this); });

            Placeholder = Field.placeholder.GetComponent<TextMeshProUGUI>();


        }



        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }


        public void AddOnValueChangeListener(UnityAction<string> function) {
            Field.onValueChanged.AddListener(function);
        }

        public void AddOnValueChangeListener(UnityAction<UIField> function) {
            Field.onValueChanged.AddListener(delegate { function?.Invoke(this); });
        }

        public void AddOnDeselectListener(UnityAction<string> function) {
            Field.onDeselect.AddListener(function);
        }

        public void AddOnDeselectListener(UnityAction<UIField> function) {
            Field.onDeselect.AddListener(delegate { function?.Invoke(this); });
        }

        public void SetOnRefreshListener(UnityAction function) {

            OnRefreshOptions.RemoveAllListeners();
            OnRefreshOptions.AddListener(function);
        }

        public void AddValidator(UnityAction<UIField> function) {
            OnValidate += function;
        }

        public void SetValidator(UnityAction<UIField> function) {
            OnValidate = function;
        }

        public void SetValue(object bbj) {
            Field.text = bbj.ToString();
        }

        public void SetValuePlacetext(object bbj) {
            Placeholder.text = bbj.ToString();
        }

        public void SetLabel(object obj) {
            string text = obj == null ? "" : obj.ToString();
            Label.text = string.Format("{0}{1}", Formatting(), text);
        }

        public string Formatting() {
            return m_labelFormats.Aggregate((a, b) => a + b);
        }

        public void SetDesc(object obj) {
            string text = obj == null ? "" : obj.ToString();
            Description.gameObject.SetActive(text != "");
            Description.text = string.Format("{0}{1}", DescFormatting(), text);
        }

        public string DescFormatting() {
            return m_descFormats.Aggregate((a, b) => a + b);
        }

        public void SetValidation(TMP_InputField.CharacterValidation charValid) {
            Field.characterValidation = charValid;
        }

        public void SetLayout(int labelMinWidth, int labelPrefWidth, int fieldMinWidth, int fieldPrefWidth) {
            LabelLayout.minWidth = labelMinWidth;
            LabelLayout.preferredWidth = labelPrefWidth;
            FieldLayout.minWidth = fieldMinWidth;
            FieldLayout.preferredWidth = fieldPrefWidth;
        }

        public void SetChoice(IChoice choice) {
            ReadyCheck();
            FieldChoice = choice;
            SetLabel(choice.Name);
        }

        public void ReadyCheck() {
            if (!Ready) {
                Construct();
                Ready = true;
                SetLabel(m_defaultLabel);
            }
        }

        public void Destroy() {
            Destroy(gameObject);
        }

        public void RefreshOptions() {
            OnRefreshOptions?.Invoke();
        }
    }
}