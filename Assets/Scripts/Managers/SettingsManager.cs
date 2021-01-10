using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Game.Managers {
    public static class SettingsManager {

        public static class TMPColour {
            public readonly static string White = "<color=#fff>";
            public readonly static string Black = "<color=#000>";
            public readonly static string Grey = "<color=#aaa>";
            public readonly static string Red = "<color=#f00>";
            public readonly static string Green = "<color=#0f0>";
            public readonly static string Blue = "<color=#00f>";
        }

        public static readonly Formatting JsonSerializerFormatting = Formatting.Indented;
        public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings {
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };
        public const string JsonDefaultPath = "Assets/Resources/Data/";

        public const float H1SizeMin = 26;
        public const float H1SizeMax = 36;
        public const float H2SizeMin = 18;
        public const float H2SizeMax = 28;
        public const float H3SizeMin = 10;
        public const float H3SizeMax = 20;

        public const float ParaSizeMin = 10;
        public const float ParaSizeMax = 12;
        public const float LogSizeMin = 10;
        public const float LogSizeMax = 16;
        public const float LabelSizeMin = 10;
        public const float LabelSizeMax = 14;
        public const float ValueSizeMin = 8;
        public const float ValueSizeMax = 12;

        public static readonly Color ButtonColorStandard = new Color32(233, 206, 129, 255);

        public static readonly Color OnValidTarget = new Color32(34, 139, 3, 255);
        public static readonly Color OnAdvantageTarget = new Color32(127, 255, 0, 255);
        public static readonly Color OnDisadvantageTarget = new Color32(255, 127, 80, 255);
        public static readonly Color OnInvalidTarget = new Color32(139, 0, 0, 255);

        public static readonly char APMainUnusedSymbol = 'A'; //⚉
        public static readonly char APMainUsedSymbol = 'a';//⚇
        public static readonly char APSubUnusedSymbol = 'R';//◍
        public static readonly char APSubUsedSymbol = 'r';//○
        public static readonly char APBonusUnusedSymbol = 'B';//⚈
        public static readonly char APBonusUsedSymbol = 'b';//⚆
        public static readonly char APLegendaryUnusedSymbol = 'S';//✪
        public static readonly char APLegendaryUsedSymbol = 's';//○

        public readonly static int IntialNumPlayers = 2;
        public readonly static int IntialNumHeros = 2;
        public readonly static int IntialNumCreatures = 3;
        public readonly static int IntialNumItems = 3;

        public readonly static int TestNumPlayers = 3;
        public readonly static int TestNumHeros = 3;
        public readonly static int TestNumCreatures = 3;
        public readonly static int TestNumItems = 3;

        public static readonly int NumDice = 4;
        public static readonly int DiceFaces = 6;
        public static readonly int TopDiceNum = 3;

        public static readonly List<int> StandardArray = new List<int>() { 8, 10, 12, 13, 14, 15 };
        public static readonly Dictionary<float, float> PointBuyCost = new Dictionary<float, float>() {
        {8, 0}, {9, 1}, {10, 2}, {11, 3}, {12, 4}, {13, 5}, {14, 7}, {15, 9}
    };
        public static readonly float TotalPointBuyCost = 27;

        public static bool Ready { get; private set; }

        // pp 5 - Always Round Down
        public const bool Midpoint = false;
        public const MidpointRounding MidpointRounding = (MidpointRounding)1;
        public const bool RoundDown = true; // pp 5 - Always Round Down


        public static readonly Dictionary<int, List<int>> DefaultSpellLimitsHero = new Dictionary<int, List<int>>() {
        { 0 , new List<int>(){ 0, -1 } },
        { 1 , new List<int>(){ 1, 2, 3, 4 } },
        { 2 , new List<int>(){ 3, 2, 4 } },
        { 3 , new List<int>(){ 5, 2, 3 } },
        { 4 , new List<int>(){ 7, 1, 2, 3 } },
        { 5 , new List<int>(){ 9, 1, 2 } },
        { 6 , new List<int>(){ 11, 1, 1, 1, 1, 1, 1, 1, 2 } },
        { 7 , new List<int>(){ 13, 1, 1, 1, 1, 1, 1, 2 } },
        { 8 , new List<int>(){ 15, 1 } },
        { 9 , new List<int>(){ 17, 1, 1 } },
    };
        public static readonly Dictionary<int, int> DefaultSpellLimitsCreature = new Dictionary<int, int>() {
        { 0, 1 }, { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 }, { 6, 1 }, { 7, 1 }, { 8, 1 }, { 9, 1 }
    };


        static SettingsManager() {
            Debug.Log("Loading SettingsManager");
            Ready = true;
        }

        public static void Load() { }

    }
}