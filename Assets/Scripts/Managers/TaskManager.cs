using UnityEngine;
using System.Collections;
using System;
using Game.Tasks;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Game.Managers {
    public static class TaskManager {

        public static List<Task> Tasks { get; private set; }
        public static Task GetRandomTask() => Tasks[UnityEngine.Random.Range(0, Tasks.Count)];
        public static UnityEvent onTaskUpdate { get; private set; }

        public static bool Ready { get; private set; }


        static TaskManager() {
            Debug.Log("Loading TaskManager");
            Tasks = new List<Task>() {
                new StandardTask("Mirror Cleaning", "Clean those mirrors, fool!", 100),
                new StandardTask("Laser pointer", "Point da lazor to the right place!", 50),
                new StandardTask("Easter Crow", "Chirp Chirp", 100),
                new StandardTask("Hello World", "Say Hi!", 200),
            };
            onTaskUpdate = new UnityEvent();
            Ready = true;
        }

        public static void Load() { }

        public static void AddTaskUpdateListener(UnityAction action) {
            onTaskUpdate.AddListener(action);
        }

        public static void RemoveTaskUpdateListener(UnityAction action) {
            onTaskUpdate.RemoveListener(action);
        }


    }
}