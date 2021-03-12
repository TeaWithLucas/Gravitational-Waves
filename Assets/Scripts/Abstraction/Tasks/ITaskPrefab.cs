using Game.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface ITaskPrefab {
    Toggle CheckBox { get; }
    Button CompleteBtn { get; }
    TaskWindow Parent { get; }
    bool Ready { get; }

    void CompleteTask();
    void SetParent(TaskWindow parent);
}