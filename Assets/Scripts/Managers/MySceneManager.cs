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

        public static string overlay = "OverlayMenu";
        public static string mainMenu = "MainMenu2";
        private static event UnityAction OnExit;

        public static bool Ready { get; private set; }


        static MySceneManager() {
            Debug.Log("Loading MySceneManager");
            AdditonalScenes = new List<string>();
            SceneManager.activeSceneChanged += OnSceneLoaded;
            Ready = true;
        }

        public static void Load() {
            
        }

        public static void LoadScene(string name) {
            OnExit?.Invoke();
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

        public static void MenuQuit(){
            OnExit?.Invoke();
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}