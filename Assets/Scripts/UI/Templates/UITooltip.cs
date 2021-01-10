using UnityEngine;
using System.Collections;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using static Game.Managers.SettingsManager;
using static Game.UI.UIFunctions;
using static Game.UI.UITemplates;
using System.Linq;
using System.Collections.Generic;

namespace Game.UI.Templates {
    [RequireComponent(typeof(Image))]
    public class UITooltip : MonoBehaviour, IUILabel, IUIImage {
        public TextMeshProUGUI Label { get; set; }
        public LayoutElement LabelLayout { get; set; }
        public TextMeshProUGUI Description { get; set; }
        public LayoutElement DescLayout { get; set; }
        public Image Image { get; set; }

        RectTransform Rect { get; set; }

        public enum Pivots {
            Top,
            Bottom,
            Left,
            Right,
        }

        public bool Ready { get; protected set; }
        public GameObject Parent { get; protected set; }

        [SerializeField]
        private string m_defaultLabel = "Label";
        [SerializeField]
        private string m_defaultDesc = "Value";
        [SerializeField]
        private List<string> m_labelFormats = new List<string>() { TMPColour.Black };
        [SerializeField]
        private List<string> m_descFormats = new List<string>() { TMPColour.Black };

        private const float m_defaultStartWait = 0.75f;
        private float m_startWait = m_defaultStartWait;

        private Dictionary<Pivots, float[]> m_pivots = new Dictionary<Pivots, float[]>() {
        { Pivots.Top, new float[] { 0.5f, 0f, 0.5f, 0f, 0.5f, 1f } },
        { Pivots.Bottom, new float[] { 0.5f, 1f, 0.5f, 1f, 0.5f, 0f } },
        { Pivots.Left, new float[] { 0f, 0.5f, 0f, 0.5f, 1f, 0.5f } },
        { Pivots.Right, new float[] { 1f, 0.5f, 1f, 0.5f, 0f, 0.5f } },
    };

        private void OnEnable() {
            if (!Ready) {
                Construct();
                EnableDescription(false);
                Ready = true;
            }
        }
        protected void Construct() {
            AddLayoutElement(gameObject).ignoreLayout = true;
            Rect = GetComponent<RectTransform>();
            Rect.anchorMin = new Vector2(0, 0);
            Rect.anchorMax = new Vector2(0, 0);
            Rect.pivot = new Vector2(0.5f, 0);

            AddSizeFitter(gameObject, ContentSizeFitter.FitMode.PreferredSize, ContentSizeFitter.FitMode.PreferredSize);

            AddLayout(gameObject, Layouts.Vertical);

            Label = CreateTextLabel("Label", gameObject, m_defaultLabel);
            Label.fontSize = 20;


            LabelLayout = Label.gameObject.AddComponent<LayoutElement>();
            LabelLayout.minHeight = 12;

            Description = CreateTextValue("Description", gameObject, m_defaultDesc);
            Description.margin = new Vector4(5, 0, 5, 5);

            DescLayout = Description.gameObject.AddComponent<LayoutElement>();
            DescLayout.minHeight = 20;
            //DescLayout.minWidth = 100;
            //DescLayout.flexibleWidth = 100;

            Image = gameObject.GetComponent<Image>();
            Image.color = new Color(Image.color.r, Image.color.b, Image.color.g, 1);

            SetLabel(m_defaultLabel);

        }

        // Use this for initialization
        void Start() {
            StartCoroutine(WaitAndEnableDescription());
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
        public void SetDesc(object obj) {
            string text = obj == null ? "" : obj.ToString();
            Description.text = string.Format("{0}{1}", ValueFormatting(), text);
        }

        public string ValueFormatting() {
            return m_descFormats.Aggregate((a, b) => a + b);
        }

        public void Destroy() {
            Destroy(gameObject);
        }

        public void SetImage(bool enabled) {
            Image.enabled = enabled;
        }

        public void SetImage(Sprite sprite) {
            Image.sprite = sprite;
        }

        public void DescDelayTime(float delay) {
            m_startWait = delay;
        }

        private IEnumerator WaitAndEnableDescription() {
            yield return new WaitForSeconds(m_startWait);
            EnableDescription(true);
            SetPos();
        }

        public void EnableDescription(bool enabled = true) {
            Description.gameObject.SetActive(enabled);
            if (enabled) {
                SizeFitterSettings(gameObject, ContentSizeFitter.FitMode.Unconstrained, ContentSizeFitter.FitMode.PreferredSize);
                Rect.sizeDelta = new Vector2(360, 92);
            } else {
                SizeFitterSettings(gameObject, ContentSizeFitter.FitMode.PreferredSize, ContentSizeFitter.FitMode.PreferredSize);
            }

        }

        public void SetParent(GameObject parent) {
            Parent = parent;
            SetPos();
        }

        public void SetPivot(Pivots pivot = Pivots.Top) {
            //float[] pivots = m_pivots[pivot];

            //Rect.anchorMin = new Vector2(pivots[0], pivots[1]);
            //Rect.anchorMax = new Vector2(pivots[2], pivots[3]);
            //Rect.pivot = new Vector2(pivots[4], pivots[5]);
        }

        public void SetPos() {
            if (Parent != null) {
                //Debug.Log(LayoutUtility.GetPreferredHeight(Rect));
                transform.position = Parent.transform.position + new Vector3(0, Parent.GetComponent<RectTransform>().sizeDelta.y / 2);
            }

        }
    }
}