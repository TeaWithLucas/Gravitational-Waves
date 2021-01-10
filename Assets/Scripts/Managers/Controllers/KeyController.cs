using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static Game.Managers.InputManager;

namespace Game.Managers.Controllers {
    public class KeyController : MonoBehaviour {

        internal GameObject GameObject;

        public bool Ready { get; private set; }

        // Start is called before the first frame update
        void Start() {
            GameObject = gameObject;
            Ready = true;
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                OnKeyEscape();
            }
            if (Input.GetKeyDown(KeyCode.F1)) {
                OnKeyF1();

            }
            if (Input.GetKeyDown(KeyCode.F10)) {
                OnKeyF10();

            }
        }
    }
}