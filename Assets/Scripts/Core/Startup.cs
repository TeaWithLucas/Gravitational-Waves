﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Game.Managers;

namespace Game.Core {

    //[InitializeOnLoad]
    public static class Startup {

        static Startup() {
            Debug.Log("Start Script - Up and running");
        }

        [RuntimeInitializeOnLoadMethod]
        static void OnRuntimeMethodLoad() {
            Debug.Log("Starting Manager Loading");
            SettingsManager.Load();
            AssetManager.Load();
            InstanceManager.Load();
            UIManager.Load();

            MySceneManager.Load();
            CameraManager.Load();
            InputManager.Load();

            Debug.Log("Finished Manager Loading");
        }
    }
}