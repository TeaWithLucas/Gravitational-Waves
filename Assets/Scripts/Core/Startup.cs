using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Game.Managers;
using System;
using System.Threading.Tasks;

namespace Game.Core {

    //[InitializeOnLoad]
    public static class Startup {

        static Startup() {
            Debug.Log("Start Script - Up and running");
        }

        [RuntimeInitializeOnLoadMethod]
        static async Task OnRuntimeMethodLoad() {
            Debug.Log("Starting Manager Loading");
            SettingsManager.Load();
            AssetManager.Load();
            InstanceManager.Load();
            UIManager.Load();

            MySceneManager.Load();
            CameraManager.Load();
            InputManager.Load();

            ActionManager.Load();
            PlayerManager.Load();
            await TaskManager.LoadAsync();
            TeamManager.Load();

            NetworkManager.Load();

            Debug.Log("Finished Manager Loading");
        }
    }
}