using UnityEngine;
using System.Collections;
using System;
using Game.Players;
using UnityEngine.Events;
using System.Linq;

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
            for (int i = 0; i < player.NumberOfTasks; i++) {
                player.AssignTask(TaskManager.GetRandomTask().Clone());
            }
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