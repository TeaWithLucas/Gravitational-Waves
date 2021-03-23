using UnityEngine;
using System.Collections;
using System;
using Game.Players;
using UnityEngine.Events;
using System.Linq;
using Game.Tasks;
using System.Collections.Generic;
using Game.Teams;

namespace Game.Managers {
    public static class PlayerManager {
        public static UnityEvent OnPlayerUpdate = new UnityEvent(); 
        public static Player LocalPlayer { get; private set; }

        public static void Load() {
            LocalPlayer = CreatePlayer("Test Player", TeamManager.Teams[0]);
            AssignRandomTasks(LocalPlayer);
        }

        public static void AssignRandomTasks(Player player) {
            var tasks = new List<Task>(TaskManager.Tasks); // temp list copy of tasks

            for (int i = 0; i < Math.Min(TaskManager.Tasks.Count, player.NumberOfTasks); i++) {

                var task = tasks[UnityEngine.Random.Range(0, tasks.Count)];
                tasks.Remove(task); // pop form assignable tasks to ensure unique tasks are assigned only
                player.AssignTask(task);
            }

            NotifyPlayerUpdate();
        }

        public static Player CreatePlayer(string name, Team team)
        {
            var player = new Player(name, team);
            
            return player;
        }

        public static void NotifyPlayerUpdate() {
            OnPlayerUpdate?.Invoke();
        } 
    }
}