using Game.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface ITaskPrefab {
    Button CompleteBtn { get; } // ????
    TaskWindow Parent { get; } // ????

    bool IsReady();
    void CompleteTask();
    void SetParent(TaskWindow parent);
}