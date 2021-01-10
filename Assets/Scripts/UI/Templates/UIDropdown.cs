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
    public class UIDropdown : MonoBehaviour {
        public LayoutGroup Layout { get; protected set; }
        public GameObject DropdownPanel { get; protected set; }
        public TMP_Dropdown Dropdown { get; protected set; }
        public LayoutElement DropdownLayout { get; protected set; }
        public TextMeshProUGUI Description { get; protected set; }
        public LayoutElement DescriptionLayout { get; protected set; }

        public IChoice DropdownChoice { get; protected set; }

        public ArrayList OptionsData { get; protected set; }
        public List<TMP_Dropdown.OptionData> Options { get; protected set; }

        public UnityEvent OnRefreshOptions { get; protected set; }

        public int Value {
            get {
                return Dropdown.value;
            }
            set {
                Dropdown.SetValueWithoutNotify(value);
            }
        }

        public bool Ready { get; protected set; }


        [SerializeField]
        private string m_defaultDesc = "Description";
        [SerializeField]
        private List<string> m_descFormats = new List<string>() { TMPColour.Black };



        private void OnEnable() {
            if (!Ready) {
                Construct();
                Ready = true;
            }
        }
        protected void Construct() {
            OnRefreshOptions = new UnityEvent();

            Layout = AddLayout(gameObject, Layouts.Vertical);

            Description = CreateTextLabel("Description", gameObject, m_defaultDesc);
            DescriptionLayout = Description.gameObject.AddComponent<LayoutElement>();
            Description.gameObject.SetActive(false);

            DropdownPanel = CreatePanel("Dropdown Panel", gameObject, false, Layouts.Horizontal);

            Dropdown = CreateDropdown("Dropdown", DropdownPanel);
            DropdownLayout = Dropdown.gameObject.AddComponent<LayoutElement>();
            DropdownLayout.minHeight = 20;
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }


        internal void AddOnValueChangeListener(UnityAction<int> function) {
            Dropdown.onValueChanged.AddListener(function);
        }

        internal void AddOnValueChangeListener(UnityAction<UIDropdown> function) {
            Dropdown.onValueChanged.AddListener(delegate { function?.Invoke(this); });
        }

        internal void SetOnValueChangeListener(UnityAction<UIDropdown> function) {
            Dropdown.onValueChanged.RemoveAllListeners();
            Dropdown.onValueChanged.AddListener(delegate { function?.Invoke(this); });
        }

        internal void SetOnRefreshListener(UnityAction function) {
            OnRefreshOptions.RemoveAllListeners();
            OnRefreshOptions.AddListener(function);
        }

        public void SetValue(int value) {
            Dropdown.value = value;
        }

        public void SetDesc(object obj) {
            string text = obj == null ? "" : obj.ToString();
            Description.gameObject.SetActive(text != "");
            Description.text = string.Format("{0}{1}", DescFormatting(), text);
        }

        public string DescFormatting() {
            return m_descFormats.Aggregate((a, b) => a + b);
        }

        public void ReadyCheck() {
            if (!Ready) {
                Construct();
                Ready = true;
            }
        }

        public void SetOptions(List<TMP_Dropdown.OptionData> options, ArrayList optionsData) {
            Options = options;
            OptionsData = optionsData;
            SetOptions(Options);
        }

        public void SetOptions(List<TMP_Dropdown.OptionData> options) {
            if (Ready) {
                //Debug.Log(options.Count);
                Dropdown.ClearOptions();
                Dropdown.options = options;
            } else {
                Debug.LogWarning("called before ready");
            }
        }

        public T GetSelectedData<T>() {
            return (T)OptionsData[Value];
        }

        public void RefreshOptions() {
            OnRefreshOptions?.Invoke();
        }

        public void Destroy() {
            Destroy(gameObject);
        }
    }
}