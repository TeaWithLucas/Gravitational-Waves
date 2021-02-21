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
                {"Choose Game", ChooseGame },
                {"Join Game", JoinGame },
                {"Host Game", HostGame },
                {"Create Game", HostGame },
                {"Environment Demo", EnvironmentDemo},
                {"Networking Demo", NetworkingDemo},
                {"Tanks Example", TanksExample },
                {"Pong Example", PongExample },
                {"Bounce Example", BounceExample },
                {"Room Example", RoomExample },
                {"Matches Example", MatchesExample },
                {"Options", OptionsMenu },
                {"Main Menu", MenuMain },
                {"Exit", MenuQuit },
                {"Quit", MenuQuit },
                
            };
            Ready = true;
        }

        public static void ChooseGame() {
            Debug.Log("Action Choose Game");
            MySceneManager.LoadScene("ChooseGame");
        }

        public static void JoinGame() {
            Debug.Log("Action Join Game");
            MySceneManager.LoadScene("JoinGame");
        }

        public static void HostGame() {
            Debug.Log("Action Host Game");
            MySceneManager.LoadScene("HostGame");
        }
        public static void OptionsMenu() {
            Debug.Log("Action Options Menu");
            MySceneManager.LoadScene("OptionsMenu");
        }

        public static void EnvironmentDemo() {
            Debug.Log("Action Environment Demo");
            MySceneManager.LoadScene("GameView");
        }

        public static void NetworkingDemo() {
            Debug.Log("Action Networking Demo");
            MySceneManager.LoadScene("Bench");
        }

        public static void TanksExample() {
            Debug.Log("Action Tanks Example");
            MySceneManager.LoadScene("Tanks");
        }

        public static void PongExample() {
            Debug.Log("Action Pong Example");
            MySceneManager.LoadScene("pong"); 
        }

        public static void BounceExample() {
            Debug.Log("Action Bounce Example");
            MySceneManager.LoadScene("BounceScene");
        }

        public static void RoomExample() {
            Debug.Log("Action Room Example");
            MySceneManager.LoadScene("OnlineScene");
        }

        public static void MatchesExample () {
            Debug.Log("Action multiplematches");
            MySceneManager.LoadScene("multiplematches");
        }

        public static void MenuMain(){
            Debug.Log("Action Main Menu");
            MySceneManager.LoadScene(MySceneManager.mainMenu);
        }

        public static void MenuQuit() {
            Debug.Log("Action Quit");
            MySceneManager.MenuQuit();
            
        }
    }
}