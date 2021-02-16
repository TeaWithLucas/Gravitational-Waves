using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace Game.Managers {
    public static class ActionManager {
        public static Dictionary<string, UnityAction> ActionListeners { get; private set; }

        public static bool Ready { get; private set; }


        static ActionManager() {
            Debug.Log("Loading ActionManager");

            ActionListeners = new Dictionary<string, UnityAction>() {
                {"Join Game", JoinGame },
                {"Host Game", HostGame },
                {"Create Game", HostGame },
                {"Tanks Example", TanksExample },
                {"Pong Example", PongExample },
                {"Bounce Example", BounceExample },
                {"Room Example", RoomExample },
                {"Matches Example", MatchesExample },
                {"Options", MenuOptions },
                {"Main Menu", MenuMain },
                {"Main Menu 2", MenuMain2 },
                {"Exit", MenuQuit },
                {"Quit", MenuQuit },
                {"TaskInteractionTestScene", TaskInteractionTestScene },
            };
            Ready = true;
        }

        public static void JoinGame() {
            MySceneManager.LoadScene("JoinGame");
        }

        public static void HostGame() {
            MySceneManager.LoadScene("HostGame");
        }

        public static void TanksExample() {
            MySceneManager.LoadScene("Tanks");
        }

        public static void PongExample() {
            MySceneManager.LoadScene("pong"); 
        }

        public static void BounceExample() {
            MySceneManager.LoadScene("BounceScene");
        }

        public static void RoomExample() {
            MySceneManager.LoadScene("OnlineScene");
        }

        public static void MatchesExample () {
            MySceneManager.LoadScene("multiplematches");
        }

        public static void MenuOptions() {
            Debug.Log("Options");
        }

        public static void MenuMain() {
            MySceneManager.LoadScene("MainMenu");
            Debug.Log("MainMenu");

        }
        public static void MenuMain2(){
            MySceneManager.LoadScene(MySceneManager.mainMenu);
            Debug.Log("MainMenu2");

        }

        public static void MenuQuit() {
            MySceneManager.MenuQuit();
            Debug.Log("Quit");
        }

        public static void TaskInteractionTestScene()
        {
            MySceneManager.LoadScene("TaskInteractionTestScene");
        }


    }
}