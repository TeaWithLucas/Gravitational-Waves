using UnityEngine;
using System.Collections;
using System;
using Game.Tasks;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;

namespace Game.Managers {
    public static class TaskManager {

        public static List<Task> Tasks { get; private set; }
        public static Task GetRandomTask() => Tasks[UnityEngine.Random.Range(0, Tasks.Count)];
        public static UnityEvent onTaskUpdate { get; private set; }

        public static bool Ready { get; private set; }


        static TaskManager() {
            Debug.Log("Loading TaskManager");
            Tasks = new List<Task>() {
                new StandardTask("MirrorCleaning", "Mirror Cleaning", "Clean those mirrors, fool!", "Mirror Cleaning Task", 100),
                new StandardTask("Laserpointer", "Laser pointer", "Point da lazor to the right place!", "Mirror Cleaning Task", 50),
                new StandardTask("EasterCrow", "Easter Crow", "Chirp Chirp", "Mirror Cleaning Task", 100),
                new StandardTask("HelloWorld", "Hello World", "Say Hi!", "Mirror Cleaning Task", 200),
            };
            onTaskUpdate = new UnityEvent();
            Ready = true;
        }

        internal static void TriggeredTask(Task task) {
            Debug.LogFormat("Task {0} triggered", task.Title);
            if (PlayerManager.LocalPlayer.AssignedTasks.Any(x => x.GetOrigin() == task && !x.IsCompleted)) {
                Task playerTask = PlayerManager.LocalPlayer.AssignedTasks.First(x => x.GetOrigin() == task && !x.IsCompleted);
                GameObject taskUI  = InstanceManager.DisplayFullscreen(playerTask.Prefab);
                ITaskPrefab taskPrefab = taskUI.GetComponent<ITaskPrefab>();
                taskPrefab.SetTask(playerTask);
                playerTask.Started();
            }
        }

        public static void Load() { }

        public static void AddTaskUpdateListener(UnityAction action) {
            onTaskUpdate.AddListener(action);
        }

        public static void RemoveTaskUpdateListener(UnityAction action) {
            onTaskUpdate.RemoveListener(action);
        }
        public static Task Task(string id) {
            if (Tasks.Any(x => x.GetID().ToLower() == id.ToLower())) {
                return Tasks.First(x => x.GetID().ToLower() == id.ToLower());
            } else {
                Debug.LogWarningFormat("No Task Found Named: {0}", id);
                return null;
            }
           
        }

    }
}