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
        public int RewardScore { get; protected set; }
        public Task Parent { get; protected set; }

        public Task(string id, string title, string description, string prefab, int rewardScore) {
            Id = id;
            Title = title;
            Description = description;
            Prefab = prefab;
            RewardScore = rewardScore;
            defaults();
        }

        public Task(Task task) {
            Parent = task;
            Id = task.Id;
            Title = task.Title;
            Description = task.Description;
            Prefab = task.Prefab;
            RewardScore = task.RewardScore;
            defaults();
        }

        private void defaults() {
            IsInProgress = false;
            IsCompleted = false;
        }

        public abstract Task Clone();

        public void Complete(bool value = true) {
            if (value) {
                Debug.LogFormat("Task {0} Completed!", Title);
                IsInProgress = false;
            } else {
                Debug.LogFormat("Task {0} reset", Title);
            }
            IsCompleted = value;
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

        public int GetRewardScore() => RewardScore;

        public string GetDescription() => Description;

        public string GetTitle() => Title;

        public Task GetOrigin() {
            return Parent == null ? this : Parent.GetOrigin();
        }
    }
}
