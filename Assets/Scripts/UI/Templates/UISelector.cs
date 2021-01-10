using Game.Core;
using Game.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Game.UI.UIFunctions;
using static Game.UI.UITemplates;

namespace Game.UI.Templates {
    public class UISelector : MonoBehaviour {

        public List<UISelection> Selections { get; set; }

        public UISelection Selected { get; private set; }

        public GameObject ButtonPanel { get; private set; }
        public LayoutElement ButtonPanelLayout { get; private set; }
        public List<UIButton> Buttons { get; private set; }

        public bool Ready { get; protected set; }

        void OnEnable() {
            if (!Ready) {
                Construct();
                Ready = true;
            }
        }

        protected void Construct() {
            //Debug.LogFormat("Constructing {0}", this);
            Selections = new List<UISelection>();

            ButtonPanel = CreatePanel("Button Panel 1", gameObject, true, Layouts.Horizontal);
            ButtonPanelLayout = AddLayoutElement(ButtonPanel.gameObject, new Vector2(-1, 100), new Vector2(-1, 150));
            DisableButtons();

            Buttons = new List<UIButton>();
        }

        // Start is called before the first frame update
        void Start() {
            //GameSetupManager.OnValueChanged.AddListener(RefreshSelection);
        }

        // Update is called once per frame
        void Update() {

        }



        private void OnDestroy() {
            //GameSetupManager.OnValueChanged.RemoveListener(RefreshSelection);
        }

        public UIButton AddButton(string name, string label, UnityAction callback, bool interactable = true) {
            EnableButtons();
            UIButton button = CreateButton(name, ButtonPanel, label);
            button.SetOnClickListener(callback);
            button.Interactable = interactable;
            Buttons.Add(button);
            return button;
        }

        internal T AddChoice<T>(IChoice choice) where T : UISelection {
            T selection = CreatePanel(choice.Name, gameObject).AddComponent<T>();
            if (ButtonPanelLayout != null && selection.SelectionLayout != null) {
                ButtonPanelLayout.minHeight = selection.SelectionLayout.minHeight;
                ButtonPanelLayout.preferredHeight = selection.SelectionLayout.preferredHeight;
            }


            //Debug.LogFormat("In {0}, Set to position: {1}", gameObject.name, gameObject.transform.childCount-2);
            selection.transform.SetSiblingIndex(gameObject.transform.childCount - 2);
            //Debug.LogFormat("Is {0} ready: {1}", typeof(T), selection.Ready);
            selection.Create(choice);
            selection.SetOnClickListenerInvoke(Select);
            Selections.Add(selection);
            if (Selections.Count == 1) {
                Select(choice);
            }
            return selection;
        }

        internal void RemoveChoice(IChoice choice) {
            GetSelector(choice).Destroy();
        }

        internal void RemoveChoice(UISelection selector) {
            selector.Destroy();
        }

        internal void ReplaceChoice(IChoice old, IChoice replacement) {
            UISelection selector = GetSelector(old);
            selector.ReplaceChoice(replacement);

            if (selector == Selected) {
                Select(replacement);
            }
        }

        internal UISelection GetSelector(IChoice choice) {
            return Selections.First(x => x.Choice == choice);
        }

        public void Select(IChoice choice) {
            Selected = GetSelector(choice);
            Selections.ForEach(x => x.ButtonToggle(false));
            Selected.ButtonToggle(true);
            //OnSelect?.Invoke(choice);
        }

        public void Select(IUIButton button) {
            if (button.GetType().IsSubclassOf(typeof(UISelection))) {
                UISelection selection = button as UISelection;
                Select(selection.Choice);
            }
        }

        public void DisableButtons() {
            ButtonPanel.SetActive(false);
        }

        public void EnableButtons() {
            ButtonPanel.SetActive(true);
        }

        public void DisableButton(string name) {
            UIButton button = Buttons.First(x => x.name == name);
            button.Button.interactable = false;
        }

        public void EnableButton(string name) {
            UIButton button = Buttons.First(x => x.name == name);
            button.Button.interactable = true;
        }

        public void Clear() {
            Buttons.ForEach(x => x.Destroy());
            Buttons.Clear();
            Selections.ForEach(x => x.Destroy());
            Selections.Clear();
            Selected = null;
        }

        public void ClearSelections() {
            Selections.ForEach(x => x.Destroy());
            Selections.Clear();
            Selected = null;
        }

        public void RefreshSelection() {
            Selected?.Refresh();
        }
    }
}