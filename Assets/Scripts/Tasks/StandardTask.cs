using System;
using Newtonsoft.Json;

namespace Game.Tasks
{
    [Serializable]
    public class StandardTask : Task {
        [JsonConstructor]
        public StandardTask(string title) : base(title)
        {
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