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
    public class UIDropdownFields : MonoBehaviour {
        public UITitle Title { get; protected set; }
        public List<UIDropdownField> Dropdowns { get; protected set; }

        public UnityAction<UIDropdownField> OnDropdownChange { get; protected set; }
        public UnityAction<UIDropdownFields> OnOptionRefresh { get; protected set; }

        public ArrayList OptionIndex { get; protected set; }

        public bool Ready { get; protected set; }

        private void OnEnable() {
            if (!Ready) {
                Construct();
                Ready = true;
            }
        }

        protected void Construct() {
            AddLayout(gameObject, Layouts.Vertical);

            Title = CreateTitle("Abilities Title", gameObject);
            Title.SetTitleSize(H2SizeMin, H2SizeMax);
            Title.Layout.padding = new RectOffset(10, 10, 10, 10);
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void SetFields(List<IChoice> choices) {
            Dropdowns = new List<UIDropdownField>();
            foreach (IChoice choice in choices) {
                UIDropdownField dropdownField = CreateDropdownField(string.Format("Stat {0} Panel", choice.Name), gameObject);
                dropdownField.SetChoice(choice);

                dropdownField.Layout.padding = new RectOffset(10, 10, 10, 10);

                dropdownField.SetLayout(100, 400, 80, 80);

                dropdownField.SetOnValueChangeListener(DropdownCallback);
                dropdownField.SetOnRefreshListener(OptionRefreshCallback);

                Dropdowns.Add(dropdownField);
            }
        }

        public void SetOptionIndex(ArrayList list) {
            OptionIndex = list;
        }

        public void SetOnDropdownChange(UnityAction<UIDropdownField> function) {
            OnDropdownChange = function;
        }

        public void SetOnOptionRefresh(UnityAction<UIDropdownFields> function) {
            OnOptionRefresh = function;
        }

        public void DropdownCallback(UIDropdownField dropdown) {
            Debug.LogFormat("Dropdown Value Change: {0}", dropdown.DropdownChoice.Name);
            OnDropdownChange?.Invoke(dropdown);
        }

        public void OptionRefreshCallback() {
            Debug.LogFormat("Option Refresh");
            OnOptionRefresh?.Invoke(this);
        }

        public void Destroy() {
            Destroy(gameObject);
        }

        public void SetTitle(object obj) {
            if (!Ready) {
                Debug.Log("Title called before ready");
                Construct();
                Ready = true;
            }
            Title.SetTitle(obj);
        }

        public void SetDesc(object obj) {
            Title.SetDesc(obj);
        }
    }
}