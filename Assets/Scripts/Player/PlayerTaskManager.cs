using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTaskManager : MonoBehaviour
{
    public int numberOfTasks;

    [Space]

    [Header("UI Components")]
    public GameObject TaskListContainer;
    public GameObject TaskListRowPrefab;

    private List<ITask> _assignedTasks = new List<ITask>();

    public void Start()
    {
        for (int i = 0; i < numberOfTasks; i++)
        {
            var task = DummyTaskRepository.GetRandomTask();
            _assignedTasks.Add(task);

            var taskRow = Instantiate(TaskListRowPrefab, TaskListContainer.transform);
            taskRow.GetComponentInChildren<TMP_Text>().text = task.GetTitle();
        }

        Debug.Log(_assignedTasks[0].GetTitle());
    }

    public List<ITask> GetAssignedTasks() => _assignedTasks;
}
