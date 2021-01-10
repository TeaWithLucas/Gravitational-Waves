using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using static Game.Managers.UIManager;

namespace Game.Managers {
    public static class MySceneManager {

        public static Scene Current { get => SceneManager.GetActiveScene(); }
        public static Scene Previous { get; private set; }

        public static List<string> AdditonalScenes { get; private set; }

        private static List<string> OverMenuScenes = new List<string>() { overlay, mainMenu };

        private static string overlay = "OverlayMenu";
        private static string mainMenu = "MainMenu";
        private static event UnityAction OnExit;

        public static Dictionary<string, UnityAction> NavigationListeners { get; private set; }

        public static bool Ready { get; private set; }


        static MySceneManager() {
            Debug.Log("Loading MySceneManager");
            AdditonalScenes = new List<string>();

            NavigationListeners = new Dictionary<string, UnityAction>() {
                {"Tanks Example", TanksExample },
                {"Pong Example", PongExample },
                {"Bounce Example", BounceExample },
                {"Room Example", RoomExample },
                {"Matches Example", MatchesExample },
                {"Options", MenuOptions },
                {"Main Menu", MenuMain },
                {"Exit Game", MenuQuit },
            };
            SceneManager.activeSceneChanged += OnSceneLoaded;
            Ready = true;
        }

        public static void Load() {
            
        }

        public static void LoadScene(string name) {
            if (name != null && name != "") {
                Debug.LogFormat("Changing Scene from {0} to {1}", Current.name, name);
                Previous = SceneManager.GetActiveScene();
                SceneManager.LoadScene(name, LoadSceneMode.Single);
                AdditonalScenes = new List<string>();
            } else {
                string error = name == null ? "Null String" : "Empty String";
                Debug.LogWarningFormat("{0} Scene Called", error);
            }

        }

        public static void OnSceneLoaded(Scene previousScene, Scene newScene) {
            InstanceManager.Init();
        }

        public static void AddScene(string name) {
            Debug.LogFormat("Adding Scene {0}", name);
            SceneManager.LoadScene(name, LoadSceneMode.Additive);
            AdditonalScenes.Add(name);
        }

        public static void RemoveScene(string name) {
            if (AdditonalScenes.Contains(name)) {
                Debug.LogFormat("Removing Scene {0}", name);
                SceneManager.UnloadSceneAsync(name);
                AdditonalScenes.Remove(name);
            }

        }

        public static void AddOnGameExitCallback(UnityAction callback) {
            OnExit += callback;
        }


        internal static void OverlayMenuToggle() {
            if (AdditonalScenes.Contains(overlay)) {
                RemoveScene(overlay);
            } else {
                if (!OverMenuScenes.Contains(Current.name)) {
                    AddScene(overlay);
                }
            }

        }

        public static void TanksExample() {
            OnExit?.Invoke();
            LoadScene("Tanks");
        }

        public static void PongExample() {
            OnExit?.Invoke();
            LoadScene("pong"); 
        }

        public static void BounceExample() {
            OnExit?.Invoke();
            LoadScene("BounceScene");
        }

        public static void RoomExample() {
            OnExit?.Invoke();
            LoadScene("OnlineScene");
        }

        public static void MatchesExample () {
            OnExit?.Invoke();
            LoadScene("multiplematches");
        }

        public static void MenuOptions() {
            Debug.Log("Options");
        }

        public static void MenuMain() {
            OnExit?.Invoke();
            LoadScene(mainMenu);
            Debug.Log("OnExit");

        }

        public static void MenuQuit() {
            OnExit?.Invoke();
            Debug.Log("Quit");
            Application.Quit();
        }


    }
}