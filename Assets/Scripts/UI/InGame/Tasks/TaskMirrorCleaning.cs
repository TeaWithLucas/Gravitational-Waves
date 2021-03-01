using Game.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskMirrorCleaning : MonoBehaviour, ITaskPrefab {

    public Button CompleteBtn { get; private set; }
    public Toggle CheckBox { get; private set; }

    public Task Task { get; private set; }

    public bool Ready { get; private set; }

    private void OnEnable() {
        if (!Ready) {
            CompleteBtn = transform.Find("Panel").Find("Complete Task Button").GetComponent<Button>();
            Debug.Log(CompleteBtn);
            CheckBox = transform.Find("Panel").Find("Click to Win Toggle").GetComponent<Toggle>();
            Debug.Log(CheckBox);
            CompleteBtn.onClick.AddListener(CompleteTask);
            Ready = true;
        }
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnDestroy() {
        //CompleteBtn.onClick.RemoveAllListeners();
    }

    public void SetTask(Task task) {
        Task = task;
    }

    public void CompleteTask() {
        Debug.LogFormat("Complete button clicked for Task {0}", Task.Title);
        if (CheckBox.isOn) {
            Task.Complete();
            Destroy(gameObject);
        }
    }
}
