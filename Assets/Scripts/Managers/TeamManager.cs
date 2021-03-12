using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Game.Teams;
using Game.Players;
using Game.Tasks;
using UnityEngine.Events;

namespace Game.Managers {
    public static class TeamManager {
      
        public static UnityEvent onPlayerUpdate { get; private set; }

        public static List<Team> Teams { get; private set; }

        public static bool Ready { get; private set; }

        static TeamManager() {
            Teams = new List<Team>();
            CreateTeams();
            onPlayerUpdate = new UnityEvent();
            Debug.Log("Loading TeamManager");
            Ready = true;
        }

        public static void Load() { }

        public static void CreateTeams(int numTeams = SettingsManager.teamsDefaultNumber) {
            for (int i = 0; i < numTeams; i++) {
                Teams.Add(new Team(string.Format("Team{0}", i + 1), string.Format("Team {0}", i + 1)));
            }
        }

        public static void AddTeamUpdateListener(UnityAction action) {
            onPlayerUpdate.AddListener(action);
        }

        public static void RemoveTeamUpdateListener(UnityAction action) {
            onPlayerUpdate.RemoveListener(action);
        }

        public static void TeamUpdated() {
            onPlayerUpdate?.Invoke();
        }
    }
}