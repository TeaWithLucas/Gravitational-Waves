using Game.Managers;
using Game.Players;
using Game.Scores;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tasks {
    [Serializable]
    public abstract class Task : ITask {
        public bool IsInProgress { get; protected set; }
        public bool IsCompleted { get; protected set; }
        public string Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Prefab { get; protected set; }
        public string Reward { get; protected set; }
        public Task Parent { get; protected set; }
        public Player Owner { get; protected set; }


        public Task(string title)
        {
            Title = title;
        }
        public Task(string id, string title, string description, string prefab, string reward) {
            Id = id;
            Title = title;
            Description = description;
            Prefab = prefab;
            Reward = reward;
        }

        public Task(Task task) {
            Parent = task;
            Id = task.Id;
            Title = task.Title;
            Description = task.Description;
            Prefab = task.Prefab;
            Reward = task.Reward;
        }

        public abstract Task Clone();

        public void Complete(bool value = true) {
            IsCompleted = value;
            if (IsCompleted) {
                Debug.LogFormat("Task {0} Completed!", Title);
                IsInProgress = false;
                ScoreManager.AddScore(Owner, Reward);
                TaskManager.TaskUpdated();
            } else {
                Debug.LogFormat("Task {0} reset", Title);
            }
        }

        internal void ToggleCompleted() {
            Complete(!IsCompleted);
        }

        internal void Started(bool value = true) {
            if (value) {
                Debug.LogFormat("Task {0} started!", Title);
            } else {
                Debug.LogFormat("Task {0} no longer started", Title);
            }
            IsInProgress = value;
        }

        public string GetID() => Id;

        public string GetDescription() => Description;

        public string GetTitle() => Title;

        public void SetOwner(Player player) {
            Owner = player;
        }

        public Task GetOrigin() {
            return Parent == null ? this : Parent.GetOrigin();
        }
    }
}
