using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace Game.Tasks {
    [Serializable]
    public class StandardTask : Task {
        public StandardTask(string title, string description, int rewardScore) : base(title, description, rewardScore) {
        }

        public StandardTask(Task task) : base(task) {
        }

        public override Task Clone() {
            return new StandardTask(this);
        }
    }
}