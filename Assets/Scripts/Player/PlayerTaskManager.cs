using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTaskManager : MonoBehaviour
{
    public int numberOfTasks;

    public List<ITask> AssignedTasks = new List<ITask>();

    public void Start()
    {
        for (int i = 0; i < numberOfTasks; i++)
        {
            AssignedTasks.Add(DummyTaskRepository.GetRandomTask());
        }
    }
}
