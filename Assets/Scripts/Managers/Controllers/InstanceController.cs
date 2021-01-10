using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Game.Managers.Controllers {
    public class InstanceController : MonoBehaviour {

        internal static GameObject GameObject;
        public bool Ready { get; private set; }

        // Start is called before the first frame update
        void Start() {
            GameObject = gameObject;
            Ready = true;
        }

        // Update is called once per frame
        void Update() {

        }
    }
}