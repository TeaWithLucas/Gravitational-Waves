using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tasks {
    [Serializable]
    public abstract class Task : ITask {
        protected bool _isInProgress = false;
        protected bool _isCompleted = false;
        protected string _id;
        protected string _title;
        protected string _description;
        protected int _rewardScore;
        protected Task parent;

        public Task(string id, string title, string description, int rewardScore) {
            _id = id;
            _title = title;
            _description = description;
            _rewardScore = rewardScore;
        }

        public Task(Task task) {
            parent = task;
            _id = task._id;
            _title = task._title;
            _description = task._description;
            _rewardScore = task._rewardScore;
        }

        public abstract Task Clone();

        public void CompleteTask() {
            _isCompleted = true;
        }

        internal void ToggleCompleted() {
            IsCompleted(!_isCompleted);
        }

        public string GetID() => _id;

        public int GetRewardScore() => _rewardScore;

        public string GetDescription() => _description;

        public string GetTitle() => _title;

        public bool IsCompleted() => _isCompleted;

        public void IsCompleted(bool value) {
            _isCompleted = value;
        }

        public bool IsInProgress() => _isInProgress;

        public Task GetOrigin() {
            return parent == null ? this : parent.GetOrigin();
        }
    }
}
