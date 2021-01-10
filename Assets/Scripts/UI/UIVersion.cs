using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {
    public class UIVersion : MonoBehaviour {

        private Text m_text;

        private void OnEnable() {
            m_text = GetComponentInChildren<Text>();
            UpdateText();
        }

        // Start is called before the first frame update
        void Start() {
            m_text = GetComponentInChildren<Text>();
            UpdateText();
        }

        // Update is called once per frame
        void Update() {

        }

        private void UpdateText() {
            if (m_text != null & Application.version != null) {
                m_text.text = string.Format("v{0}", Application.version);
            }
        }
    }
}