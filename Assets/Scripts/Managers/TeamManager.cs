using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Game.Teams;
using Game.Players;
using Game.Tasks;

namespace Game.Managers {
    public static class TeamManager {
       
        public static bool Ready { get; private set; }

        public static List<Team> Teams { get; private set; }


        static TeamManager() {
            Debug.Log("Loading TeamManager");
            Ready = true;
        }

        public static void Load() { }
    }
}