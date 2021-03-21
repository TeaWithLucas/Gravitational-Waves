using UnityEngine;
using System.Collections;
using System;
using Game.Players;
using UnityEngine.Events;
using System.Linq;
using Game.Tasks;
using System.Collections.Generic;

namespace Game.Managers {
    public static class PlayerManager {

        public static bool Ready { get; private set; }

        public static UnityEvent onPlayerUpdate { get; private set; }
        public static Player LocalPlayer { get; private set; }

        static PlayerManager() {
            Debug.Log("Loading PlayerManager");
            LocalPlayer = new Player("Test Player", TeamManager.Teams.First());
            onPlayerUpdate = new UnityEvent();
            Ready = true;
        }

        public static void Load() { }

        public static void AssignRandomTasks(Player player) {
            Debug.Log(TaskManager.Tasks.Count);

            var tasks = new List<Task>(TaskManager.Tasks); // temp list copy of tasks

            for (int i = 0; i < Math.Min(TaskManager.Tasks.Count, player.NumberOfTasks); i++) {

                var task = tasks[UnityEngine.Random.Range(0, tasks.Count)];
                tasks.Remove(task); // pop form assignable tasks to ensure unique tasks are assigned only
                player.AssignTask(task);
            }

            Debug.Log(TaskManager.Tasks.Count);
        }

        public static void AddPlayerUpdateListener(UnityAction action) {
            onPlayerUpdate.AddListener(action);
        }

        public static void RemovePlayerUpdateListener(UnityAction action) {
            onPlayerUpdate.RemoveListener(action);
        }

        public static void PlayerUpdated() {
            onPlayerUpdate?.Invoke();
        } 
    }
}