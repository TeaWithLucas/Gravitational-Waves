using Game.Managers;
using Game.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskWindow : MonoBehaviour {

    public GameObject Window { get; private set; }
    public Button CloseWindowBtn { get; private set; }
    public GameObject TaskContainer { get; private set; }
    public ITaskPrefab TaskInstance { get; private set; }
    public TMP_Text TaskTitle { get; private set; }

    public string TaskCorrectAnswer { get; private set; }

    public string TaskExternalURL{ get; private set; }

    public GenericTaskManager GenericTaskManager;

    public Task Task { get; private set; }

    public bool Ready { get; private set; }

    private void OnEnable() {
        if (!Ready) {

            CloseWindowBtn = transform.Find("Close Button").GetComponent<Button>();

            Window = transform.Find("Window").gameObject;
            TaskTitle = Window.transform.Find("Title").GetComponentInChildren<TMP_Text>();
            TaskContainer = Window.transform.Find("Container").gameObject;

            CloseWindowBtn.onClick.AddListener(CloseWindow);
            Ready = true;
        }
    }

    private void OnDestroy() {
        CloseWindowBtn.onClick.RemoveAllListeners();
    }

    public void SetTask(Task task) {
        Task = task;
        TaskTitle.text = task.Title;
        if (task is GenericTask genericTask)
        {
            var genericTaskGameObject = InstanceManager.Instantiate("GenericTask", TaskContainer);
            TaskInstance = genericTaskGameObject.GetComponent<ITaskPrefab>();

            var genericTaskManager = genericTaskGameObject.GetComponent<GenericTaskManager>();

            genericTaskManager.SetTask(genericTask);
        }
        else
        {
            TaskInstance = InstanceManager.Instantiate(task.Prefab, TaskContainer).GetComponent<ITaskPrefab>();

        }

        Task.Owner.HasTaskOpen = true;
        TaskInstance.SetParent(this);
    }

    public void CompleteTask() {
        Debug.LogFormat("Task {0} Completed, closing window", Task.Title);
        Task.Complete();
        CloseWindow();
    }

    public void CloseWindow() {
        Task.Owner.HasTaskOpen = false;
        Destroy(gameObject);
    }
}