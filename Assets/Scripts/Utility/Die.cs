using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Utility {
    public class Die {
        public int Min { get; protected set; }
        public int Max { get; protected set; }

        public Stack<int> History { get; protected set; }
        [JsonIgnore]
        public Stack<int> Review { get; protected set; }

        [JsonIgnore]
        public int Last => History.Peek();
        [JsonIgnore]
        public int NumRolls => History.Count;
        [JsonIgnore]
        public int Previous => Review.Pop();
        [JsonIgnore]
        public int Faces => Max + 1 - Min;

        public Die(int min, int max) {
            History = new Stack<int>();
            Min = min;
            Max = max;
        }

        public Die(int faces) : this(1, faces) { }

        public Die(Die parent) : this(parent.Min, parent.Max) {
            History = new Stack<int>(parent.History);
            if (parent.History.Count > 1) {
                Review = new Stack<int>(parent.History);
                Review.Pop();
            } else {
                Review = new Stack<int>();
            }
        }

        [JsonConstructor]
        public Die(int Min, int Max, Stack<int> History) : this(Min, Max) {
            this.History = new Stack<int>(History);
            if (History.Count > 1) {
                Review = new Stack<int>(History);
                Review.Pop();
            } else {
                Review = new Stack<int>();
            }
        }

        public int Roll() {
            int roll = Random.Range(Min, Max + 1);
            Review = new Stack<int>(History);
            History.Push(roll);
            return roll;
        }

        public Die Clone() {
            return new Die(this);
        }
    }
}