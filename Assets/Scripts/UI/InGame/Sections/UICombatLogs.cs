using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Game.UI.UITemplates;
using static Game.UI.UIFunctions;
using System.Linq;
using Game.UI.Templates;
using Game.UI.InGame.Sections.Items;
using Game.Core;

namespace Game.UI.InGame.Sections {
    public class UICombatLogs : MonoBehaviour {
        public GameObject ButtonPanel { get; private set; }
        public UIButton TestButton { get; private set; }
        public UIButton CameraHome { get; private set; }

        public ScrollRect CombatLogView { get; private set; }
        public GameObject CombatLogContainer { get; private set; }



        public bool Active {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }

        private bool TxtUpdated = false;
        private string CombatLog = "";

        public bool Ready { get; private set; }

        private void OnEnable() {
            if (!Ready) {

                ButtonPanel = CreatePanel("Button Panel", gameObject, Layouts.Horizontal);
                AddLayoutElement(ButtonPanel, new Vector2(-1, 30), new Vector2(-1, -1));

                CombatLogView = CreateScrollView("Combat Log Panel", gameObject);
                AddLayoutElement(CombatLogView.gameObject, new Vector2(-1, -1), new Vector2(-1, 800));
                CombatLogView.horizontal = false;
                CombatLogContainer = CombatLogView.content.gameObject;

                AddLayout(CombatLogContainer, Layouts.Vertical);
                AddSizeFitter(CombatLogContainer, Layouts.Vertical);

                Logs.OnPushCombatLog = PushedCombatLog;


                foreach (UILog log in Logs.CombatLogs.ToList()) {
                    log.transform.SetParent(CombatLogContainer.transform);
                    log.transform.SetAsLastSibling();
                }

                Ready = true;
            }
        }



        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        private void OnDestroy() {
            Logs.OnPushCombatLog -= PushedCombatLog;
        }

        private void PushedCombatLog(UILog log) {
            log.transform.SetParent(CombatLogContainer.transform);
            ResetScrollPos();
        }

        public void ResetScrollPos() {
            if (Ready && gameObject.activeSelf) {
                StartCoroutine(resetScrollPos());
            }
        }

        IEnumerator resetScrollPos() {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            CombatLogView.verticalScrollbar.value = 0.0f;
            TxtUpdated = false;
        }
    }
}