using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Managers {
    public static class UIManager {

        public enum Layout {
            Vertical,
            Horizontal,
            Grid,
            VerticalLooseV,
            VerticalCSizeV,
            VerticalCSizeH,
            VerticalCSizeVH,
        }

        private static TMP_DefaultControls.Resources m_TMP_UI_Resources = new TMP_DefaultControls.Resources();
        private static DefaultControls.Resources m_UI_Resources = new DefaultControls.Resources();

        private static Dictionary<string, List<string>> m_textTooltipLinkData = new Dictionary<string, List<string>>();

        public static bool Ready { get; private set; }
        static UIManager() {
            Debug.Log("Loading UIManager");
            MySceneManager.AddOnGameExitCallback(OnGameExit);
            m_textTooltipLinkData = new Dictionary<string, List<string>>();
            m_TMP_UI_Resources.background = AssetManager.Sprite("Background");
            m_UI_Resources.background = AssetManager.Sprite("Background");
            m_TMP_UI_Resources.checkmark = AssetManager.Sprite("Checkmark");
            m_UI_Resources.checkmark = AssetManager.Sprite("Checkmark");
            m_TMP_UI_Resources.dropdown = AssetManager.Sprite("DropdownArrow");
            m_UI_Resources.dropdown = AssetManager.Sprite("DropdownArrow");
            m_TMP_UI_Resources.inputField = AssetManager.Sprite("InputFieldBackground");
            m_UI_Resources.inputField = AssetManager.Sprite("InputFieldBackground");
            m_TMP_UI_Resources.knob = AssetManager.Sprite("Knob");
            m_UI_Resources.knob = AssetManager.Sprite("Knob");
            m_TMP_UI_Resources.mask = AssetManager.Sprite("UIMask");
            m_UI_Resources.mask = AssetManager.Sprite("UIMask");
            m_TMP_UI_Resources.standard = AssetManager.Sprite("UISprite");
            m_UI_Resources.standard = AssetManager.Sprite("UISprite");
            Ready = true;
        }

        public static void Load() { }

        public static void OnGameExit() {
            Debug.Log("Clearing UIManager");
        }

        public static void TooltipLink(string id, string label, string desc = null) {
            id = id.Replace(" ", "").ToLower();
            if (m_textTooltipLinkData.ContainsKey(id)) {
                m_textTooltipLinkData[id] = new List<string>() { label, desc };
            } else {
                m_textTooltipLinkData.Add(id, new List<string>() { label, desc });
            }
        }

        public static List<string> TooltipLink(string id) {
            id = id.Replace(" ", "").ToLower();
            if (m_textTooltipLinkData.ContainsKey(id)) {
                return m_textTooltipLinkData[id];
            } else {
                TooltipLink(id, string.Format("{0}: *Missing*", id), null);
                return TooltipLink(id);
            }
        }

        public static GameObject CreateButton() {
            GameObject obj = DefaultControls.CreateButton(m_UI_Resources);
            return obj;
        }

        public static GameObject CreateButton(string name, GameObject parent) {
            GameObject obj = DefaultControls.CreateButton(m_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateTMPButton() {
            GameObject obj = TMP_DefaultControls.CreateButton(m_TMP_UI_Resources);
            return obj;
        }

        public static GameObject CreateTMPButton(string name, GameObject parent) {
            GameObject obj = TMP_DefaultControls.CreateButton(m_TMP_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateDropdown() {
            GameObject obj = DefaultControls.CreateDropdown(m_UI_Resources);
            return obj;
        }

        public static GameObject CreateDropdown(string name, GameObject parent) {
            GameObject obj = DefaultControls.CreateDropdown(m_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateTMPDropdown() {
            GameObject obj = TMP_DefaultControls.CreateDropdown(m_TMP_UI_Resources);
            return obj;
        }

        public static GameObject CreateTMPDropdown(string name, GameObject parent) {
            GameObject obj = TMP_DefaultControls.CreateDropdown(m_TMP_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateImage() {
            GameObject obj = DefaultControls.CreateImage(m_UI_Resources);
            return obj;
        }

        public static GameObject CreateImage(string name, GameObject parent) {
            GameObject obj = DefaultControls.CreateImage(m_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateInputField() {
            GameObject obj = DefaultControls.CreateInputField(m_UI_Resources);
            return obj;
        }

        public static GameObject CreateInputField(string name, GameObject parent) {
            GameObject obj = DefaultControls.CreateInputField(m_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateTMPInputField() {
            GameObject obj = TMP_DefaultControls.CreateInputField(m_TMP_UI_Resources);
            obj.SetActive(false);
            obj.SetActive(true);
            return obj;
        }

        public static GameObject CreateTMPInputField(string name, GameObject parent) {
            GameObject obj = TMP_DefaultControls.CreateInputField(m_TMP_UI_Resources);
            obj.SetActive(false);
            obj.SetActive(true);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreatePanel() {
            GameObject obj = DefaultControls.CreatePanel(m_UI_Resources);
            return obj;
        }

        public static GameObject CreatePanel(string name) {
            GameObject obj = DefaultControls.CreatePanel(m_UI_Resources);
            obj.name = name;
            return obj;
        }

        public static GameObject CreatePanel(string name, GameObject parent = null) {
            GameObject obj = DefaultControls.CreatePanel(m_UI_Resources);
            if(parent != null) {
                obj.transform.SetParent(parent.transform);
            }
            obj.name = name;
            return obj;
        }

        public static GameObject CreateRawImage() {
            GameObject obj = DefaultControls.CreateRawImage(m_UI_Resources);
            return obj;
        }

        public static GameObject CreateRawImage(string name, GameObject parent) {
            GameObject obj = DefaultControls.CreateRawImage(m_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateScrollbar() {
            GameObject obj = DefaultControls.CreateScrollbar(m_UI_Resources);
            return obj;
        }

        public static GameObject CreateScrollbar(string name, GameObject parent) {
            GameObject obj = DefaultControls.CreateScrollbar(m_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateTMPScrollbar() {
            GameObject obj = TMP_DefaultControls.CreateScrollbar(m_TMP_UI_Resources);
            return obj;
        }

        public static GameObject CreateTMPScrollbar(string name, GameObject parent) {
            GameObject obj = TMP_DefaultControls.CreateScrollbar(m_TMP_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateScrollView() {
            GameObject obj = DefaultControls.CreateScrollView(m_UI_Resources);
            return obj;
        }

        public static GameObject CreateScrollView(string name, GameObject parent) {
            GameObject obj = DefaultControls.CreateScrollView(m_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateSlider() {
            GameObject obj = DefaultControls.CreateSlider(m_UI_Resources);
            return obj;
        }

        public static GameObject CreateSlider(string name, GameObject parent) {
            GameObject obj = DefaultControls.CreateSlider(m_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateText() {
            GameObject obj = DefaultControls.CreateText(m_UI_Resources);
            return obj;
        }

        public static GameObject CreateText(string name, GameObject parent) {
            GameObject obj = DefaultControls.CreateText(m_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateTMPText() {
            GameObject obj = TMP_DefaultControls.CreateText(m_TMP_UI_Resources);
            return obj;
        }

        public static GameObject CreateTMPText(string name, GameObject parent) {
            GameObject obj = TMP_DefaultControls.CreateText(m_TMP_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }

        public static GameObject CreateToggle() {
            GameObject obj = DefaultControls.CreateToggle(m_UI_Resources);
            return obj;
        }

        public static GameObject CreateToggle(string name, GameObject parent) {
            GameObject obj = DefaultControls.CreateToggle(m_UI_Resources);
            obj.transform.SetParent(parent.transform);
            obj.name = name;
            return obj;
        }


    }
}