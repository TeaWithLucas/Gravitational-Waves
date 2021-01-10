using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI {
    public static class UIFunctions {

        public enum Padding {
            None,
            Full,
            Half,
            Spacing,
        }

        private static Dictionary<Padding, float[]> PaddingValues = new Dictionary<Padding, float[]>() {
        { Padding.None,     new float[] { 0, 0, 0, 0, 0, 0 } },
        { Padding.Full,     new float[] { 10, 10, 10, 10, 5, 5 } },
        { Padding.Half,     new float[] { 5, 5, 5, 5, 2, 2 } },
        { Padding.Spacing,  new float[] { 0, 0, 0, 0, 10, 10 } },
    };

        public enum Layouts {
            Vertical,
            Horizontal,
            Grid,
        }

        private static Dictionary<Layouts, Type> LayoutValues = new Dictionary<Layouts, Type>() {
        { Layouts.Vertical,      typeof(VerticalLayoutGroup) },
        { Layouts.Horizontal,    typeof(HorizontalLayoutGroup) },
        { Layouts.Grid,          typeof(GridLayoutGroup) },
    };

        private static Dictionary<Layouts, ContentSizeFitter.FitMode[]> SizeFitterValues = new Dictionary<Layouts, ContentSizeFitter.FitMode[]>() {
        { Layouts.Vertical,      new ContentSizeFitter.FitMode[] { ContentSizeFitter.FitMode.Unconstrained, ContentSizeFitter.FitMode.PreferredSize } },
        { Layouts.Horizontal,    new ContentSizeFitter.FitMode[] { ContentSizeFitter.FitMode.PreferredSize, ContentSizeFitter.FitMode.Unconstrained } },
        { Layouts.Grid,          new ContentSizeFitter.FitMode[] { ContentSizeFitter.FitMode.Unconstrained, ContentSizeFitter.FitMode.Unconstrained } },
    };

        public static bool Ready { get; private set; }

        static UIFunctions() {
            Ready = true;
        }

        public static LayoutGroup AddLayout(GameObject obj, Layouts layout) {
            LayoutGroup comp = obj.AddComponent(LayoutValues[layout]) as LayoutGroup;
            return comp;
        }

        public static LayoutGroup AddLayout(GameObject obj, Layouts layout, bool controlHorizontal, bool controlVertical) {
            LayoutGroup comp = obj.AddComponent(LayoutValues[layout]) as LayoutGroup;
            VHLayoutSettings(obj, controlHorizontal, controlVertical);
            return comp;
        }

        public static LayoutElement AddLayoutElement(GameObject obj) {
            LayoutElement comp = obj.AddComponent<LayoutElement>();
            return comp;
        }
        public static LayoutElement AddLayoutElement(GameObject obj, Vector2 min, Vector2 pref) {
            LayoutElement comp = obj.AddComponent<LayoutElement>();
            comp.minWidth = min.x;
            comp.minHeight = min.y;
            comp.preferredWidth = pref.x;
            comp.preferredHeight = pref.y;
            return comp;
        }

        public static LayoutElement AddLayoutElement(GameObject obj, Vector2 flex) {
            LayoutElement comp = obj.AddComponent<LayoutElement>();
            comp.flexibleWidth = flex.x;
            comp.flexibleHeight = flex.y;
            return comp;
        }

        public static ContentSizeFitter AddSizeFitter(GameObject obj, ContentSizeFitter.FitMode horizontalFit, ContentSizeFitter.FitMode verticalFit) {
            ContentSizeFitter comp = obj.AddComponent<ContentSizeFitter>();
            SizeFitterSettings(comp, horizontalFit, verticalFit);
            return comp;
        }

        public static ContentSizeFitter AddSizeFitter(GameObject obj, Layouts layout) {
            ContentSizeFitter comp = obj.AddComponent<ContentSizeFitter>();
            SizeFitterSettings(comp, SizeFitterValues[layout][0], SizeFitterValues[layout][1]);
            return comp;
        }

        public static Button AddButton(GameObject obj) {
            Button comp = obj.AddComponent<Button>();
            return comp;
        }

        internal static void SetRectAnchors(GameObject obj) {
            RectTransform comp = obj.GetComponent<RectTransform>();
            comp.anchorMin = new Vector2(0f, 0f);
            comp.anchorMax = new Vector2(1f, 1f);
            comp.offsetMin = new Vector2(0f, 0f);
            comp.offsetMax = new Vector2(0f, 0f);
        }

        internal static void SetRectAnchors(GameObject obj, Vector2 min, Vector2 max) {
            RectTransform comp = obj.GetComponent<RectTransform>();
            comp.anchorMin = min;
            comp.anchorMax = max;
            comp.offsetMin = new Vector2(0f, 0f);
            comp.offsetMax = new Vector2(0f, 0f);
        }

        internal static void SetRectAnchors(GameObject obj, Vector2 min, Vector2 max, Vector2 pivot) {
            RectTransform comp = obj.GetComponent<RectTransform>();
            comp.anchorMin = min;
            comp.anchorMax = max;
            comp.offsetMin = new Vector2(0f, 0f);
            comp.offsetMax = new Vector2(0f, 0f);
            comp.pivot = pivot;
        }

        internal static void SetRectPivot(GameObject obj, Vector2 pivot) {
            RectTransform comp = obj.GetComponent<RectTransform>();
            comp.pivot = pivot;
        }

        internal static void SetOffset(GameObject obj, Vector2 min, Vector2 max) {
            RectTransform comp = obj.GetComponent<RectTransform>();
            comp.offsetMin = min;
            comp.offsetMax = max;
        }

        internal static void SetHeight(GameObject obj, float height) {
            RectTransform comp = obj.GetComponent<RectTransform>();
            comp.sizeDelta = new Vector2(comp.sizeDelta.x, height);
        }
        internal static void SetWidth(GameObject obj, float width) {
            RectTransform comp = obj.GetComponent<RectTransform>();
            comp.sizeDelta = new Vector2(width, comp.sizeDelta.y);
        }

        internal static void SetPadding(GameObject obj, Padding padding) {
            LayoutGroup layout = obj.GetComponent<LayoutGroup>();
            if (layout != null) {
                if (layout.GetType().IsSubclassOf(typeof(HorizontalOrVerticalLayoutGroup))) {
                    HorizontalOrVerticalLayoutGroup hvLayout = layout as HorizontalOrVerticalLayoutGroup;
                    SetPadding(hvLayout, PaddingValues[padding]);
                } else if (layout.GetType() == typeof(GridLayoutGroup) || layout.GetType().IsSubclassOf(typeof(GridLayoutGroup))) {
                    GridLayoutGroup gridLayout = layout as GridLayoutGroup;
                    SetPadding(gridLayout, PaddingValues[padding]);
                } else {
                    SetPadding(layout, PaddingValues[padding]);
                }
            }

        }

        internal static void SetPadding(LayoutGroup comp, int left, int right, int top, int bottom) {
            comp.padding = new RectOffset(left, right, top, bottom);
        }

        internal static void SetPadding(LayoutGroup comp, float[] values) {
            comp.padding = new RectOffset((int)values[0], (int)values[1], (int)values[2], (int)values[3]);
        }

        internal static void SetPadding(HorizontalOrVerticalLayoutGroup comp, int left, int right, int top, int bottom, float spacing) {
            comp.padding = new RectOffset(left, right, top, bottom);
            comp.spacing = spacing;
        }

        internal static void SetPadding(HorizontalOrVerticalLayoutGroup comp, float[] values) {
            comp.padding = new RectOffset((int)values[0], (int)values[1], (int)values[2], (int)values[3]);
            comp.spacing = values[4];
        }

        internal static void SetPadding(GridLayoutGroup comp, float[] values) {
            //Debug.Log("Setting GridLayoutGroup Padding");
            comp.padding = new RectOffset((int)values[0], (int)values[1], (int)values[2], (int)values[3]);
            comp.spacing = new Vector2(values[4], values[5]);
        }


        internal static void SetSpacing(HorizontalOrVerticalLayoutGroup comp, float spacing) {
            comp.spacing = spacing;
        }

        internal static void SetMargin(TextMeshProUGUI comp, Vector4 margin) {
            comp.margin = margin;
        }

        internal static void SetTextMeshPro(GameObject obj, float fontMax, float fontMin) {
            TextMeshPro comp = obj.GetComponent<TextMeshPro>();
            comp.enableAutoSizing = true;
            comp.fontSizeMin = fontMin;
            comp.fontSizeMax = fontMax;
        }

        internal static void SetTextMeshProUGUI(GameObject obj, float fontMin, float fontMax) {
            TextMeshProUGUI comp = obj.GetComponent<TextMeshProUGUI>();
            comp.enableAutoSizing = true;
            comp.fontSizeMin = fontMin;
            comp.fontSizeMax = fontMax;
        }

        internal static void SetImageColor(GameObject obj, float r, float g, float b, float a) {
            Image comp = obj.GetComponent<Image>();
            comp.color = new Color(r / 255f, g / 255f, b / 255f, a / 100f);
        }

        internal static void SetImageColor(GameObject obj, float r, float g, float b) {
            Image comp = obj.GetComponent<Image>();
            comp.color = new Color(r / 255f, g / 255f, b / 255f);
        }

        internal static void SetImageSprite(GameObject obj, Sprite sprite) {
            Image comp = obj.GetComponent<Image>();
            comp.sprite = sprite;
        }

        internal static void SetImageSprite(GameObject obj, Sprite sprite, Image.Type type) {
            Image comp = obj.GetComponent<Image>();
            comp.sprite = sprite;
            comp.type = type;
        }

        internal static void DisableImage(GameObject obj) {
            EnableImage(obj, false);
        }
        internal static void EnableImage(GameObject obj) {
            EnableImage(obj, true);
        }
        internal static void EnableImage(GameObject obj, bool enabled) {
            EnableImage(obj.GetComponent<Image>(), enabled);
        }

        internal static void EnableImage(Image comp, bool enabled) {
            comp.enabled = enabled;
        }

        internal static void SliderSettings(Slider comp, bool wholeNumbers, float min, float max) {
            comp.wholeNumbers = wholeNumbers;
            comp.minValue = min;
            comp.maxValue = max;
            comp.value = min;
        }


        internal static void VHLayoutSettings(GameObject obj, bool controlHorizontal, bool controlVertical) {
            VHLayoutSettings(obj, controlHorizontal, controlVertical, !controlHorizontal, !controlVertical);
        }
        internal static void VHLayoutSettings(GameObject obj, bool controlHorizontal, bool controlVertical, bool useChildHorizontal, bool useChildVertical) {
            HorizontalOrVerticalLayoutGroup comp = obj.GetComponent<HorizontalOrVerticalLayoutGroup>();
            if (comp != null) {
                VHLayoutSettings(comp, controlHorizontal, controlVertical, useChildHorizontal, useChildVertical);
            } else {
                Debug.LogWarningFormat("Err: {0} has no HorizontalOrVerticalLayoutGroup", obj);
            }
        }

        internal static void VHLayoutSettings(HorizontalOrVerticalLayoutGroup comp, bool controlHorizontal, bool controlVertical, bool useChildHorizontal, bool useChildVertical) {
            comp.childControlWidth = controlHorizontal;
            comp.childControlHeight = controlVertical;
            comp.childForceExpandWidth = controlHorizontal;
            comp.childForceExpandHeight = controlVertical;
            comp.childScaleHeight = useChildVertical;
            comp.childScaleWidth = useChildHorizontal;
        }



        public static void SizeFitterSettings(GameObject obj, ContentSizeFitter.FitMode horizontalFit, ContentSizeFitter.FitMode verticalFit) {
            ContentSizeFitter comp = obj.GetComponent<ContentSizeFitter>();
            if (comp != null) {
                SizeFitterSettings(comp, horizontalFit, verticalFit);
            } else {
                Debug.LogWarningFormat("Err: {0} has no ContentSizeFitter", obj);
            }
        }

        public static void SizeFitterSettings(ContentSizeFitter comp, ContentSizeFitter.FitMode horizontalFit, ContentSizeFitter.FitMode verticalFit) {
            comp.horizontalFit = horizontalFit;
            comp.verticalFit = verticalFit;
        }

        public static void InputFieldSettings(TMP_InputField comp, TMP_InputField.CharacterValidation charValid) {
            comp.characterValidation = charValid;
        }

        public static void InputFieldSettings(TMP_InputField comp, TMP_InputField.InputType inputType) {
            comp.inputType = inputType;
        }

        internal static void AddSliderListener(Slider comp, UnityAction<float> function) {
            comp.onValueChanged.AddListener(function);
        }

        internal static void AddButtonListener(Button comp, UnityAction function) {
            comp.onClick.AddListener(function);
        }

        internal static void AddButtonListener(Button comp, UnityAction<float> function, float value) {
            comp.onClick.AddListener(delegate { function.Invoke(value); });
        }

        internal static void AddInputFieldListener(InputField comp, UnityAction<string> function) {
            comp.onValueChanged.AddListener(function);
        }

        internal static void AddInputFieldListener(TMP_InputField comp, UnityAction<string> function) {
            comp.onValueChanged.AddListener(function);
        }

        internal static void AddInputFieldListener(TMP_InputField comp, UnityAction<TMP_InputField> function) {
            comp.onValueChanged.AddListener(delegate { function.Invoke(comp); });
        }
    }
}