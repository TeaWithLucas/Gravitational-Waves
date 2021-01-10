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

namespace Game.UI.Templates {
    public class UITitle : MonoBehaviour {
        public LayoutGroup Layout { get; protected set; }
        public TextMeshProUGUI Title { get; protected set; }
        public LayoutElement TitleLayout { get; protected set; }
        public TextMeshProUGUI Description { get; protected set; }
        public LayoutElement DescriptionLayout { get; protected set; }

        public bool Ready { get; protected set; }
        [SerializeField]
        private string m_defaultTitle = "Tile";
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
                SetTitle(m_defaultTitle);
            }
        }
        protected void Construct() {
            Layout = AddLayout(gameObject, Layouts.Vertical);

            Title = CreateTextH1("Title", gameObject, m_defaultTitle);
            TitleLayout = Title.gameObject.AddComponent<LayoutElement>();

            Description = CreateTextLabel("Description", gameObject, m_defaultDesc);
            DescriptionLayout = Description.gameObject.AddComponent<LayoutElement>();
            Description.gameObject.SetActive(false);
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void SetTitle(object obj) {
            if (!Ready) {
                Debug.Log("Title called before ready");
                Construct();
                Ready = true;
            }
            string text = obj == null ? "" : obj.ToString();
            Title.text = string.Format("{0}{1}", Formatting(), text);
        }

        public string Formatting() {
            return m_labelFormats.Aggregate((a, b) => a + b);
        }

        public void SetTitleSize(float minSize, float maxSize) {
            if (!Ready) {
                Debug.Log("Title called before ready");
                Construct();
                Ready = true;
            }
            Title.enableAutoSizing = true;
            Title.fontSizeMin = minSize;
            Title.fontSizeMax = maxSize;
        }

        public void SetTitleSize(float size = H1SizeMax) {
            Title.enableAutoSizing = false;
            Title.fontSize = size;
        }

        public void SetDesc(object obj) {
            string text = obj == null ? "" : obj.ToString();
            Description.gameObject.SetActive(text != "");
            Description.text = string.Format("{0}{1}", DescFormatting(), text);
        }

        public string DescFormatting() {
            return m_descFormats.Aggregate((a, b) => a + b);
        }
    }
}