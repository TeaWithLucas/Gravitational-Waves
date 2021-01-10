using Game.Managers;
using Game.UI.InGame.Sections.Items;
using Game.UI.Templates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static Game.Managers.SettingsManager;
using static Game.Managers.InstanceManager;

namespace Game.UI {
    public static class UITemplates {
        public static bool Ready { get; private set; }

        static UITemplates() {
            Ready = true;
        }

        public static TextMeshProUGUI CreateText(string name, GameObject parent, string text, float fontSizeMax = 40, bool autoSizing = false, float fontSizeMin = 10) {
            GameObject obj = UIManager.CreateTMPText(name, parent);
            TextMeshProUGUI comp = obj.GetComponent<TextMeshProUGUI>();
            comp.fontSize = fontSizeMax;
            comp.enableAutoSizing = autoSizing;
            comp.fontSizeMin = fontSizeMin;
            comp.fontSizeMax = fontSizeMax;
            comp.text = TMPColour.White + text;
            return comp;
        }

        public static TextMeshProUGUI CreateTextH1(string name, GameObject parent, string text, bool autoSizing = false) {
            GameObject obj = UIManager.CreateTMPText(name, parent);
            TextMeshProUGUI comp = obj.GetComponent<TextMeshProUGUI>();
            comp.enableAutoSizing = autoSizing;
            comp.fontSize = H1SizeMax;
            comp.fontSizeMin = H1SizeMin;
            comp.fontSizeMax = H1SizeMax;
            comp.text = TMPColour.White + text;
            return comp;
        }

        public static TextMeshProUGUI CreateTextH2(string name, GameObject parent, string text, bool autoSizing = false) {
            GameObject obj = UIManager.CreateTMPText(name, parent);
            TextMeshProUGUI comp = obj.GetComponent<TextMeshProUGUI>();
            comp.enableAutoSizing = autoSizing;
            comp.fontSize = H2SizeMax;
            comp.fontSizeMin = H2SizeMin;
            comp.fontSizeMax = H2SizeMax;
            comp.text = TMPColour.White + text;
            return comp;
        }

        public static TextMeshProUGUI CreateTextH3(string name, GameObject parent, string text, bool autoSizing = false) {
            GameObject obj = UIManager.CreateTMPText(name, parent);
            TextMeshProUGUI comp = obj.GetComponent<TextMeshProUGUI>();
            comp.enableAutoSizing = autoSizing;
            comp.fontSize = H3SizeMax;
            comp.fontSizeMin = H3SizeMin;
            comp.fontSizeMax = H3SizeMax;
            comp.text = TMPColour.White + text;
            return comp;
        }



        public static TextMeshProUGUI CreateTextPara(string name, GameObject parent, string text, bool autoSizing = false) {
            GameObject obj = UIManager.CreateTMPText(name, parent);
            TextMeshProUGUI comp = obj.GetComponent<TextMeshProUGUI>();
            comp.enableAutoSizing = autoSizing;
            comp.fontSize = ParaSizeMax;
            comp.fontSizeMin = ParaSizeMin;
            comp.fontSizeMax = ParaSizeMax;
            comp.text = TMPColour.White + text;
            return comp;
        }

        public static TextMeshProUGUI CreateTextLog(string name, GameObject parent) {
            GameObject obj = UIManager.CreateTMPText(name, parent);
            TextMeshProUGUI comp = obj.GetComponent<TextMeshProUGUI>();
            comp.fontSize = LogSizeMax;
            comp.margin = new Vector4(5, 5, 5, 5);
            comp.text = TMPColour.Black;

            return comp;
        }

        public static TextMeshProUGUI CreateTextLabel(string name, GameObject parent, string text, bool autoSizing = false) {
            GameObject obj = UIManager.CreateTMPText(name, parent);
            TextMeshProUGUI comp = obj.GetComponent<TextMeshProUGUI>();
            comp.enableAutoSizing = autoSizing;
            comp.fontSize = LabelSizeMax;
            comp.fontSizeMin = LabelSizeMin;
            comp.fontSizeMax = LabelSizeMax;
            comp.text = TMPColour.White + text;
            comp.alignment = TextAlignmentOptions.MidlineLeft;
            comp.margin = new Vector4(5, 5, 5, 5);
            return comp;
        }

        public static TextMeshProUGUI CreateTextValue(string name, GameObject parent, string text, bool autoSizing = false) {
            GameObject obj = UIManager.CreateTMPText(name, parent);
            TextMeshProUGUI comp = obj.GetComponent<TextMeshProUGUI>();
            comp.enableAutoSizing = autoSizing;
            comp.fontSize = ValueSizeMax;
            comp.fontSizeMin = ValueSizeMin;
            comp.fontSizeMax = ValueSizeMax;
            comp.text = TMPColour.White + text;
            comp.alignment = TextAlignmentOptions.MidlineLeft;
            comp.margin = new Vector4(5, 5, 5, 5);
            return comp;
        }

        public static UILabelValue CreateLabelValue(string name, GameObject parent) {
            GameObject obj = CreatePanel(name, parent);
            UILabelValue comp = obj.AddComponent<UILabelValue>();
            return comp;
        }

        public static UIDropdownFields CreateDropdownFields(string name, GameObject parent) {
            GameObject obj = CreatePanel(name, parent, false);
            UIDropdownFields comp = obj.AddComponent<UIDropdownFields>();
            return comp;
        }

        public static UIDropdownField CreateDropdownField(string name, GameObject parent) {
            GameObject obj = CreatePanel(name, parent);
            UIDropdownField comp = obj.AddComponent<UIDropdownField>();
            return comp;
        }

        public static UITitle CreateTitle(string name, GameObject parent, string title = null, string desc = null) {
            GameObject obj = CreatePanel(name, parent, false);
            UITitle comp = obj.AddComponent<UITitle>();
            if (title != null) {
                comp.SetTitle(title);
                if (desc != null) {
                    comp.SetDesc(desc);
                }
            }
            return comp;
        }

        public static TMP_Dropdown CreateDropdown(string name, GameObject parent) {
            GameObject obj = UIManager.CreateTMPDropdown(name, parent);
            TMP_Dropdown comp = obj.GetComponent<TMP_Dropdown>();
            comp.ClearOptions();
            return comp;
        }

        public static UIDropdown CreateUIDropdown(string name, GameObject parent) {
            GameObject obj = CreatePanel(name, parent);
            UIDropdown comp = obj.AddComponent<UIDropdown>();
            return comp;
        }


        public static TMP_InputField CreateInputField(string name, GameObject parent) {
            GameObject obj = UIManager.CreateTMPInputField(name, parent);
            TMP_InputField comp = obj.GetComponent<TMP_InputField>();
            return comp;
        }

        public static UIField CreateField(string name, GameObject parent, bool background = true) {
            GameObject obj = CreatePanel(name, parent, background);
            UIField comp = obj.AddComponent<UIField>();
            return comp;
        }
        public static UIFields CreateFields(string name, GameObject parent) {
            GameObject obj = CreatePanel(name, parent, false);
            UIFields comp = obj.AddComponent<UIFields>();
            return comp;
        }

        public static ScrollRect CreateScrollView(string name, GameObject parent) {
            GameObject obj = UIManager.CreateScrollView(name, parent);
            ScrollRect comp = obj.GetComponent<ScrollRect>();
            return comp;
        }

        public static Slider CreateSlider(string name, GameObject parent) {
            GameObject obj = UIManager.CreateSlider(name, parent);
            Slider comp = obj.GetComponent<Slider>();
            return comp;
        }

        public static UIButton CreateButton(string name, GameObject parent, string label = "Button") {
            GameObject obj = UIManager.CreateTMPButton(name, parent);
            UIButton comp = obj.AddComponent<UIButton>();
            comp.SetLabel(label);
            return comp;
        }

        internal static Image CreateImage(string name, GameObject parent, string spriteName = null) {
            GameObject obj = UIManager.CreateImage(name, parent);
            Image comp = obj.GetComponent<Image>();
            if (spriteName != null) {
                comp.sprite = AssetManager.Sprite(spriteName);
            }
            return comp;
        }

        public static GameObject CreatePanel(string name, GameObject parent = null) {
            GameObject obj = UIManager.CreatePanel(name, parent);
            UIFunctions.SetRectAnchors(obj);
            return obj;
        }

        public static GameObject CreatePanel(string name, GameObject parent, bool background) {
            GameObject obj = UIManager.CreatePanel(name, parent);
            UIFunctions.SetRectAnchors(obj);
            UIFunctions.EnableImage(obj, background);
            obj.GetComponent<Image>().enabled = background;
            return obj;
        }

        public static GameObject CreatePanel(string name, GameObject parent, UIFunctions.Layouts layout) {
            GameObject obj = UIManager.CreatePanel(name, parent);
            UIFunctions.AddLayout(obj, layout);
            return obj;
        }

        public static GameObject CreatePanel(string name, GameObject parent, bool background, UIFunctions.Layouts layout) {
            GameObject obj = UIManager.CreatePanel(name, parent);
            UIFunctions.AddLayout(obj, layout);
            UIFunctions.EnableImage(obj, background);
            return obj;
        }

        public static UITabs CreateTabs(string name, GameObject parent) {
            GameObject obj = CreatePanel(name, parent);
            UITabs comp = obj.AddComponent<UITabs>();
            return comp;
        }

        public static UITooltip CreateTooltip(string name, GameObject parent) {
            GameObject obj = CreatePanel(name, InstanceManager.Canvas.gameObject);
            UITooltip comp = obj.AddComponent<UITooltip>();
            comp.SetParent(parent);
            return comp;
        }


        public static UILog CreateLog(GameObject parent) {
            GameObject obj = CreatePanel("Log", parent);
            UILog comp = obj.AddComponent<UILog>();
            return comp;
        }

        public static UISelector CreateSelector(string name, GameObject parent, bool background = false) {
            GameObject obj = CreatePanel(name, parent);
            UISelector comp = obj.AddComponent<UISelector>();
            return comp;
        }

    }
}