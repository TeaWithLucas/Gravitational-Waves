using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tasks {
    [Serializable]
    public abstract class Task : ITask {
        protected bool _isInProgress = false;
        protected bool _isCompleted = false;
        protected string _title;
        protected string _description;
        protected int _rewardScore;

        public Task(string title, string description, int rewardScore) {
            _title = title;
            _description = description;
            _rewardScore = rewardScore;
        }

        public Task(Task task) {
            _title = task._title;
            _description = task._description;
            _rewardScore = task._rewardScore;
        }

        public void CompleteTask() {
            _isCompleted = true;
        }

        public int GetRewardScore() => _rewardScore;

        public string GetDescription() => _description;

        public string GetTitle() => _title;

        public bool IsCompleted() => _isCompleted;

        public void IsCompleted(bool value) {
            _isCompleted = value;
        }

        public bool IsInProgress() => _isInProgress;

        public abstract Task Clone();
    }
}
