using Game.Managers;
using Game.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(InteractionListener))]
public class InteractiveTask : MonoBehaviour {

    public string TaskName = "HelloWorld";

    public Task Task { get; private set; }

    public bool Ready { get; private set; }

    public InteractionListener InteractionListener { get; private set; }
    private void OnEnable() {
        InteractionListener = gameObject.GetComponent<InteractionListener>();
        Task = TaskManager.Task(TaskName);
    }


    private void Start() {
        if (!Ready) {
            if (Task != null) {
                InteractionListener.OnInteraction.AddListener(Trigger);
                Ready = true;
            }
        }
    }

    private void Update() {

    }

    private void OnDestroy() {
        InteractionListener.OnInteraction.RemoveListener(Trigger);
    }

    public void Trigger() {
        TaskManager.TriggeredTask(Task);
    }
}
