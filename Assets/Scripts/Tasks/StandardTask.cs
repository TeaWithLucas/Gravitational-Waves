using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Newtonsoft.Json;

namespace Game.Tasks {
    [Serializable]
    public class StandardTask : Task {

        [JsonConstructor]
        public StandardTask(){
        }
        public StandardTask(string id, string title, string description, string prefab, string reward) : base(id, title, description, prefab, reward) {
        }

        public StandardTask(Task task) : base(task) {
        }

        public override Task Clone() {
            return new StandardTask(this);
        }
    }
}