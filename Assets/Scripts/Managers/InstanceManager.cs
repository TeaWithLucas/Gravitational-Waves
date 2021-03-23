using Game.Managers.Controllers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Managers
{
    public static class InstanceManager {

        public static Canvas Canvas { get; private set; }
        public static GameObject FullScreen { get; private set; }
        public static GameObject WindowsSection { get; private set; }

        public static List<GameObject> GameObjects { get; private set; }

        public static bool Ready { get; private set; }

        static InstanceManager() {
            Init();
            Debug.Log("Loading InstanceManager");
        }

        public static void Load() { }

        public static void Init(GameObject parent = null) {

            GameObjects = new List<GameObject>();
            Canvas = Object.FindObjectOfType<Canvas>();
            Debug.Log(Canvas);
            CameraManager.Reset();
            if (Canvas.transform.Find("Player UI")) {
                FullScreen = Canvas.transform.Find("Player UI").Find("Fullscreen").gameObject;
                WindowsSection = Canvas.transform.Find("Player UI").Find("View Area").Find("Middle Section").Find("Windows Section").gameObject;
            } else {
                FullScreen = null;
                WindowsSection = null;
            }

            Ready = true;
        }

        public static GameObject GetGameObject(string name) {
            return GameObjects.First(x => x.name == name);
        }

        public static GameObject InstantiateActor(string name, GameObject parent) {
            GameObject obj = Object.Instantiate(GetGameObject(name), parent.transform);
            obj.name = "Body";
            obj.SetActive(true);
            return obj;
        }

        public static GameObject DisplayFullscreen(string name) {
            if (FullScreen) {
                return Instantiate(name, FullScreen);
            } else {
                return null;
            }
            
        }
        
        public static GameObject DisplayWindow(string name) {
            if (FullScreen) {
                return Instantiate(name, WindowsSection);
            } else {
                return null;
            }
        }

        internal static GameObject Instantiate(string prefabID, GameObject parent) {
            return Instantiate(prefabID, parent.transform);
        }

        internal static GameObject Instantiate(string prefabID, Transform parent) {
            GameObject prefab = AssetManager.Prefab(prefabID);
            GameObject instance = Object.Instantiate(prefab, parent);
            return instance;
        }
    }
}