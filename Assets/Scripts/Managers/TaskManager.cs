using UnityEngine;
using System.Collections;
using System;
using Game.Tasks;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;
using Game.Teams;

namespace Game.Managers {
    public static class TaskManager {

        public static List<Task> Tasks { get; private set; }
        public static Task GetRandomTask() => Tasks[UnityEngine.Random.Range(0, Tasks.Count)];
        public static UnityEvent onTaskUpdate { get; private set; }

        public static bool Ready { get; private set; }


        static TaskManager() {
            Debug.Log("Loading TaskManager");
            Tasks = new List<Task>() {
                new StandardTask("MirrorCleaning", "Mirror Cleaning", "Clean those mirrors, fool!", "Mirror Cleaning Task", "Reward1"),
                new StandardTask("WaveformFitter", "Waveform Fitter", "Fit da Waveform", "Waveform Fitter Task", "Reward2"),
                new StandardTask("Range", "Range", "Get the waveform in the correct area?", "Range Task", "Reward3"),
                new StandardTask("Laserpointer", "Laser pointer", "Point da lazor to the right place!", "Mirror Cleaning Task", "Reward2"),
                new StandardTask("KeycodeTask", "KeycodeTask", "fuck u", "KeycodeTask", "NOTHING"),
                new StandardTask("HelloWorld", "Hello World", "Say Hi!", "Mirror Cleaning Task", "Reward4"),
            };
            onTaskUpdate = new UnityEvent();
            Ready = true;
        }

        internal static void TriggeredTask(Task task) {
            if (PlayerManager.LocalPlayer.HasTaskOpen) return; // Player already has a task open. Avoiding opening tasks multiple times

            Debug.LogFormat("Task {0} triggered", task.Title);

            var playerTask = PlayerManager.LocalPlayer.AssignedTasks.FirstOrDefault(x => x.GetOrigin() == task && !x.IsCompleted);

            if (playerTask != null) {
                GameObject taskUI = InstanceManager.DisplayFullscreen("Task UI Framework");
                TaskWindow taskPrefab = taskUI.GetComponent<TaskWindow>();
                taskPrefab.SetTask(playerTask);
                PlayerManager.LocalPlayer.HasTaskOpen = true;
            }
        }

        public static async System.Threading.Tasks.Task LoadAsync() {
            var tasks = await GenericTaskReader.ReadTasksFromDiskAsync();

        }

        public static void AddTaskUpdateListener(UnityAction action) {
            onTaskUpdate.AddListener(action);
        }

        public static void RemoveTaskUpdateListener(UnityAction action) {
            onTaskUpdate.RemoveListener(action);
        }
        public static Task Task(string id) {
            return Tasks.FirstOrDefault(x => x.GetID().ToLower() == id.ToLower());
        }

        public static void TaskUpdated() {
            onTaskUpdate?.Invoke();
            PlayerManager.PlayerUpdated();
            TeamManager.TeamUpdated();
        }

    }
}