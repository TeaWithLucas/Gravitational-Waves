using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static Game.Managers.InputManager;

namespace Game.Managers.Controllers {
    public class MouseController : MonoBehaviour {

        internal GameObject GameObject;
        public enum MouseCode {
            Left = 0,
            Right = 1,
            Middle = 2
        }

        public bool Ready { get; private set; }

        // Start is called before the first frame update
        void Start() {
            GameObject = gameObject;
            Ready = true;
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetMouseButtonDown((int)MouseCode.Left)) {
                OnMouseLeft();
            }
        }
    }
}