using Game.Tasks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskMirrorCleaning : MonoBehaviour, ITaskPrefab {

    public Button CompleteBtn { get; private set; }
    public Toggle CheckBox { get; private set; }
    public TaskWindow Parent { get; private set; }

    private bool ready;

    public bool IsReady()
    {
        return ready;
    }

    private void SetReady(bool value)
    {
        ready = value;
    }

    private void OnEnable() {
        if (!IsReady()) {

            CompleteBtn = transform.Find("Complete Task Button").GetComponent<Button>();
            CheckBox = transform.Find("Click to Win Toggle").GetComponent<Toggle>();
            SetReady(true);
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnDestroy() {
        CompleteBtn.onClick.RemoveAllListeners();
    }

    public void SetParent(TaskWindow parent) {
        Parent = parent;
        CompleteBtn.onClick.AddListener(CompleteTask);
        StartTask();
    }

    public void StartTask() {
        Parent.Task.Started();
    }

    public void CompleteTask() {
        Debug.LogFormat("Complete button clicked for Task {0}", Parent.Task.Title);
        if (CheckBox.isOn) {
            Parent.CompleteTask();
        }
    }
}