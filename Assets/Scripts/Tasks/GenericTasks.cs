using System;
using Newtonsoft.Json;

namespace Game.Tasks
{
    [Serializable]
    public class GenericTask : Task
    {
        [JsonProperty("task_url")]
        public string Url { get; set; }

        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; set; }


        [JsonConstructor]
        public GenericTask(string id, string title, string description, string prefab, string reward, string url, string correctAnswer) : base(id, title, description, prefab, reward)
        {
            Url = url;
            CorrectAnswer = correctAnswer;
        }

        public GenericTask(Task task) : base(task)
        {
        }

        public override Task Clone()
        {
            return new GenericTask(this);
        }
    }
}