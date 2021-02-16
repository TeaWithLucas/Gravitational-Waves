using Game.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.UI.Menu {
    public class UIMenuButtons : MonoBehaviour {
        public List<Button> Buttons;
        public List<string> Scenes;

        // Start is called before the first frame update
        void Start() {
            //Buttons = transform.GetComponentsInChildren<Button>().ToList();
            AssignListenerCallbacks();
        }

        // Update is called once per frame
        void Update() {

        }

        private void AssignListenerCallbacks() {
            for (int i = 0; i < Buttons.Count; i++){

                string scene = Scenes[i];
                Buttons[i].onClick.AddListener(delegate {Debug.Log("Loading scene:" + scene);  MySceneManager.LoadScene(scene);  });
            }
        }
    }
}