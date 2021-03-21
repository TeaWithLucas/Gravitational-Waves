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
        [RuntimeInitializeOnLoadMethod]
        static async Task OnRuntimeMethodLoad() {
            Debug.Log("Starting Manager Loading");
            await TaskManager.LoadAsync();

            SettingsManager.Load();
            AssetManager.Load();
            InstanceManager.Load();
            
            PlayerManager.Load();

            UIManager.Load();

            MySceneManager.Load();
            CameraManager.Load();
            InputManager.Load();

            ActionManager.Load();
            

            TeamManager.Load();

            NetworkManager.Load();

            Debug.Log("Finished Manager Loading");
        }
    }
}