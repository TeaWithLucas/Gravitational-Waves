using Game.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.UI.Menu {
    public class UIMainMenu : MonoBehaviour {
        public List<Button> Buttons { get; protected set; }

        private

        // Start is called before the first frame update
        void Start() {
            Buttons = transform.GetComponentsInChildren<Button>().ToList();
            AssignListenerCallbacks();
        }

        // Update is called once per frame
        void Update() {

        }

        private void AssignListenerCallbacks() {
            foreach (Button button in Buttons) {
                if (ActionManager.ActionListeners.Keys.Any(x => button.name.ToLower().Contains(x.ToLower()))) {
                    button.onClick.AddListener(ActionManager.ActionListeners.First(x => button.name.ToLower().Contains(x.Key.ToLower())).Value);
                } else {
                    Debug.LogWarningFormat("No Action found for button: {0}", button.name);
                }
            }
        }
    }
}