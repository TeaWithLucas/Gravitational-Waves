using UnityEngine;
using System.Collections;
using static Game.UI.UITemplates;
using static Game.UI.UIFunctions;
using TMPro;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Game.UI.Templates;
using Game.Managers;

namespace Game.UI.InGame.Sections.Items {
    public class UILog : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

        public TextMeshProUGUI Log { get; protected set; }
        public bool Ready { get; protected set; }

        public int NewTooltipID => m_curTooltipID++;

        private Dictionary<string, List<string>> m_textTooltipLinkData = new Dictionary<string, List<string>>();
        private UITooltip m_tooltip;
        private string CurLinkID;
        private int m_curTooltipID = 0;

        private bool m_hovering = false;

        private void OnEnable() {
            if (!Ready) {
                Construct();
            }
        }

        protected void Construct() {
            DateTime localDate = DateTime.Now;
            name = string.Format("Log-{0}", localDate);
            Debug.LogFormat("Constructing log {0}", name);
            AddSizeFitter(gameObject, Layouts.Vertical);
            HorizontalOrVerticalLayoutGroup layout = AddLayout(gameObject, Layouts.Vertical) as HorizontalOrVerticalLayoutGroup;

            //layout.childScaleHeight = true;
            //layout.childControlHeight = false;

            Log = CreateTextLog("Log Text", gameObject);
            AddSizeFitter(Log.gameObject, Layouts.Vertical);

            //Log.text += "<link=\"Pie\">PIIIIIIIIIIIIIE</link>";
            //TooltipLink("Pie", "Pie", "Pie");
            //Debug.LogFormat("TMP links length: {0}", Log.textInfo.linkInfo.Length);

            Ready = true;
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if (m_hovering && Ready) {
                SetTooltip();
            } else if (m_tooltip != null && Ready) {
                DestroyTooltip();
            }
        }

        public void OnPointerEnter(PointerEventData eventData) {
            m_hovering = true;
            Debug.LogFormat("Hovering over: {0}", name);
        }

        public void OnPointerExit(PointerEventData eventData) {
            m_hovering = false;
            Debug.LogFormat("No Longer hovering over: {0}", name);
        }

        private void SetTooltip() {
            int index = FindLinkIndex();
            if (index >= 0) {

                TMP_LinkInfo link = LinkInfo(index);
                string linkID = link.GetLinkID();
                if (linkID != CurLinkID) {
                    CurLinkID = linkID;
                    Debug.LogFormat("Index found {0}", linkID);
                    List<string> linkData;

                    if (m_textTooltipLinkData.ContainsKey(linkID.ToLower())) {
                        linkData = TooltipLink(linkID);
                    } else {
                        linkData = UIManager.TooltipLink(linkID);
                    }

                    if (m_tooltip == null) {
                        m_tooltip = CreateTooltip(string.Format("{0} tooltip", name), gameObject);
                        m_tooltip.DescDelayTime(0f);
                    }

                    string label = linkData[0];
                    string desc = linkData[1];
                    m_tooltip.SetLabel(label);

                    if (desc != null) {
                        m_tooltip.SetDesc(desc);
                    }
                    m_tooltip.SetPivot(UITooltip.Pivots.Top);
                }
            } else {
                CurLinkID = null;
                //Debug.LogFormat("No Index found");
                DestroyTooltip();
            }
        }

        public void DestroyTooltip() {
            if (m_tooltip != null) {
                m_tooltip.Destroy();
            }
        }

        public void AddText(string text) {
            if (text != null) {
                Log.text += text;
            }
        }

        public void AddText(string format, params object[] args) {

            if (format != null) {
                AddText(string.Format(format, args));
            }
        }

        public void TooltipLink(string id, string label, string desc = null) {
            id = id.Replace(" ", "").ToLower();
            if (m_textTooltipLinkData.ContainsKey(id)) {
                m_textTooltipLinkData[id] = new List<string>() { label, desc };
            } else {
                m_textTooltipLinkData.Add(id, new List<string>() { label, desc });
            }
        }

        public List<string> TooltipLink(string id) {
            id = id.Replace(" ", "").ToLower();
            return m_textTooltipLinkData[id];
        }

        public int FindLinkIndex() {
            return TMP_TextUtilities.FindIntersectingLink(Log, InputManager.GetMousePos(), null);
        }

        public TMP_LinkInfo LinkInfo(int index) {
            return Log.textInfo.linkInfo[index];
        }
    }
}