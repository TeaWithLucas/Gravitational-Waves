using Game.Extensions;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Utility {
    public class Dice {

        public List<Die> Die { get; protected set; }
        [JsonIgnore]
        public int Count => Die.Count();
        [JsonIgnore]
        public Die First { get => Die.First(); }
        [JsonIgnore]
        public int Sum => Die.Select(c => { return c.Last; }).Sum();
        [JsonIgnore]
        public int[] Values => Die.Select(c => { return c.Last; }).ToArray();
        [JsonIgnore]
        public Die TopDie => Die.OrderByDescending(i => { return i.Last; }).First();
        [JsonIgnore]
        public Die BottomDie => Die.OrderByDescending(i => { return i.Last; }).Last();
        [JsonIgnore]
        public string DieType => Die.Select(x => { return x.Faces; }).GroupBy(x => x).Select(x => { return string.Format("{0}d{1}", x.Count(), x.Key); }).Commaise();
        [JsonIgnore]
        public string DieValues => Die.Select(x => { return x.Last.ToString(); }).Commaise();

        public Dice() {
            Die = new List<Die>();
        }

        public Dice(int count, int faces) : this() {
            Add(count, faces);
        }

        public Dice(Dice parent) : this(parent.Die) { }

        [JsonConstructor]
        public Dice(List<Die> Die) {
            if (Die == null) {
                Debug.LogWarning("Set Null");
                this.Die = new List<Die>();
            } else {
                this.Die = Die.Select(x => x.Clone()).ToList();
            }

        }

        public void Add(int faces) {
            Die die = new Die(faces);
            Die.Add(die);
        }

        public void Add(int count, int faces) {
            for (int i = 0; i < count; i++) {
                Add(faces);
            }
        }

        public void AddRoll(int faces) {
            Die die = new Die(faces);
            die.Roll();
            Die.Add(die);
        }

        public void AddRoll(int count, int faces) {
            for (int i = 0; i < count; i++) {
                AddRoll(faces);
            }
        }


        public void Remove(int firstIdx, int lastIdx) {
            Die.RemoveRange(firstIdx, lastIdx);
        }

        public void Remove(int count) {
            Die.RemoveRange(Die.Count - 1 - count, Die.Count);
        }
        public void RemoveAt(int index) {
            Die.RemoveAt(index - 1);
        }

        public void RemoveLast() {
            Remove(Die.Count - 1);
        }

        public void RemoveAll() {
            Clear();
        }

        public void Clear() {
            Die.Clear();
        }

        public void RemoveNum(int count) {
            int last = Die.Count - 1;
            Remove(last - count, last);
        }

        public int Roll(int index) {
            Die die = Die[index];
            die.Roll();
            return die.Last;
        }

        public int[] Roll() {
            return Die.Select(c => { return c.Roll(); }).ToArray();
        }

        public int[] Roll(int firstIdx, int lastIdx) {
            return Die.GetRange(firstIdx, lastIdx).Select(c => { return c.Roll(); }).ToArray();
        }

        public Dice TopDice(int count) {
            return new Dice(Die.OrderByDescending(i => { return i.Last; }).Take(count).ToList());
        }
        public int TopDiceSum(int count) {
            return Die.OrderByDescending(i => { return i.Last; }).Take(count).Select(x => x.Last).Sum();
        }

        public int Advantage(int advantage = 1) {
            if (advantage > 0) {
                return Die.OrderByDescending(i => { return i.Last; }).First().Last;
            } else if (advantage < 0) {
                return Die.OrderByDescending(i => { return i.Last; }).Last().Last;
            } else {
                return Die.First().Last;
            }
        }

        public int Disadvantage() {
            return Advantage(-1);
        }

        public Dice Clone() {
            return new Dice(this);
        }

    }
}