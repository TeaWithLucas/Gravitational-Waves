using UnityEngine;
using System.Collections;
using System;
using System.Net;
using Game.Tasks;
using System.Collections.Generic;
using Game.Managers;
using System.Linq;

namespace Game.Players {
    public class Player {
        public string Name { get; private set; }
        public bool IsHost { get; private set; }


        public List<Task> AssignedTasks { get; private set; }
        public string Description { get; internal set; }
        public string Thumbnail { get; internal set; }

        public int numberOfTasks = SettingsManager.taskDefaultNumber;

        public Player(string name = "player") {
            Name = name;
            Description = "Player Description";
            Thumbnail = "gravitationalwaves";
            AssignedTasks = new List<Task>();
            IsHost = false;
            PlayerManager.AssignRandomTasks(this);
        }

        public void SetName(string value) {
            Name = value;
        }

        public void SetIsHost(bool value) {
            IsHost = value;
        }
    
        public void AssignTask(Task task) {
            AssignedTasks.Add(task);
        }

        public float PercentageTasksComplete() {
            int tasksComplete = AssignedTasks.Count(x => x.IsCompleted());
            float percentage = ((float)tasksComplete / AssignedTasks.Count()) * 100;
            Debug.LogFormat("Task Completed: {0}/{1} - {2}%", tasksComplete, AssignedTasks.Count(), percentage);
            return percentage;
        }
    }
}