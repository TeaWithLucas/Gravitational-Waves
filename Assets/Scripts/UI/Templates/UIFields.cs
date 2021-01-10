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
    public class UIFields : MonoBehaviour {
        public UITitle Title { get; protected set; }
        public List<UIField> Fields { get; protected set; }

        public UnityAction<UIField> OnFieldChange { get; protected set; }
        public UnityAction<UIFields> OnOptionRefresh { get; protected set; }
        public UnityAction<UIField> Validator { get; protected set; }
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
            Fields = new List<UIField>();
            foreach (IChoice choice in choices) {
                UIField field = CreateField(string.Format("Stat {0} Panel", choice.Name), gameObject);
                field.SetChoice(choice);
                field.Layout.padding = new RectOffset(10, 10, 10, 10);
                field.SetValuePlacetext("#");
                field.SetLayout(100, 400, 50, 50);
                field.SetValidation(TMP_InputField.CharacterValidation.Integer);
                field.AddOnDeselectListener(FieldCallback);
                field.SetOnRefreshListener(OptionRefreshCallback);
                field.AddValidator(Validator);

                Fields.Add(field);
            }
        }

        public void SetOptionIndex(ArrayList list) {
            OptionIndex = list;
        }

        public void SetOnFieldDeselect(UnityAction<UIField> function) {
            OnFieldChange = function;
        }
        public void SetOnOptionRefresh(UnityAction<UIFields> function) {
            OnOptionRefresh = function;
        }

        public void SetValidator(UnityAction<UIField> function) {
            Validator = function;
        }

        public void FieldCallback(UIField field) {
            //Debug.LogFormat("Field Value Change: {0}", field.FieldChoice.Name);
            Validator?.Invoke(field);
            OnFieldChange?.Invoke(field);
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