using UnityEngine;
using System.Collections;
using System;
using System.Net;
using Game.Tasks;
using System.Collections.Generic;
using Game.Managers;
using System.Linq;
using Mirror;
using Game.Teams;

namespace Game.Players {
    public class Player {
        public string Name { get; protected set; }
        public bool IsHost { get; protected set; }
        public NetworkConnectionToClient Conn { get; protected set; }

        public List<Task> AssignedTasks { get; protected set; }
        public string Thumbnail { get; protected set; }

        public int NumberOfTasks { get; protected set; }
        public Team Team { get; protected set; }

        public int Score { get; protected set; }

        public Player(string name, Team team) {
            Name = name;
            Thumbnail = "gravitationalwaves-tex";
            AssignedTasks = new List<Task>();
            IsHost = false;

            NumberOfTasks = SettingsManager.taskDefaultNumber;
            PlayerManager.AssignRandomTasks(this);
            Team = team;
            Score = 0;
        }

        internal void AddScore(int value) {
            Score += value;
        }

        public void SetName(string value) {
            Name = value;
        }

        public string GetDescription() {
            return string.Format("Score: {0}", Score);
        }

        public void SetIsHost(bool value) {
            IsHost = value;
        }
    
        public void AssignTask(Task task) {
            task.SetOwner(this);
            AssignedTasks.Add(task);
        }

        public float PercentageTasksComplete() {
            int tasksComplete = AssignedTasks.Count(x => x.IsCompleted);
            float percentage = ((float)tasksComplete / AssignedTasks.Count()) * 100;
            Debug.LogFormat("Task Completed: {0}/{1} - {2}%", tasksComplete, AssignedTasks.Count(), percentage);
            return percentage;
        }
    }
}