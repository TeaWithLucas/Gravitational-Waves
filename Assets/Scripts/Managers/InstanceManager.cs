using Game.Managers.Controllers;
using Game.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Game.Managers {
    public static class InstanceManager {

        public static GameObject Operator { get; private set; }
        public static GameObject InstanceController { get; private set; }
        public static GameObject KeyController { get; private set; }
        public static GameObject MouseController { get; private set; }
        public static GameObject TempStorage { get; private set; }
        public static GameObject CharactersContainer { get; private set; }
        public static GameObject ObjectInstancesContainer { get; private set; }
        public static Canvas Canvas { get; private set; }

        public static List<GameObject> GameObjects { get; private set; }

        public static bool Ready { get; private set; }

        static InstanceManager() {
            Init();
            Debug.Log("Loading InstanceManager");
        }

        public static void Load() { }

        public static void Init(GameObject parent = null) {
            if (parent == null) {
                Operator = new GameObject("Operator", typeof(Operator));
            } else {
                Operator = parent;
            }
            

            InstanceController = new GameObject("Instance Controller", typeof(InstanceController));
            InstanceController.transform.SetParent(Operator.transform);

            KeyController = new GameObject("Key Controller", typeof(KeyController));
            KeyController.transform.SetParent(Operator.transform);

            MouseController = new GameObject("Mouse Controller", typeof(MouseController));
            MouseController.transform.SetParent(Operator.transform);

            TempStorage = new GameObject("Temp Storage");
            TempStorage.transform.SetParent(Operator.transform);

            Canvas = UnityEngine.Object.FindObjectOfType<Canvas>();
            Debug.Log(Canvas);
            CameraManager.Reset();
            InitGameObjects();

            Ready = true;
        }

        public static void SetupCharacters() {
            CharactersContainer = new GameObject("Characters");
            CharactersContainer.transform.SetParent(Operator.transform);
        }

        private static void InitGameObjects() {
            ObjectInstancesContainer = new GameObject("Assets");
            ObjectInstancesContainer.transform.SetParent(Operator.transform);

            GameObjects = new List<GameObject>();

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = "Cube";
            cube.transform.SetParent(ObjectInstancesContainer.transform);
            cube.SetActive(false);
            GameObjects.Add(cube);

            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            capsule.name = "Capsule";
            capsule.transform.SetParent(ObjectInstancesContainer.transform);
            Vector3 newScale = new Vector3(0.8f, 1.2f, 0.8f);
            capsule.transform.localScale = newScale;
            CapsuleCollider collider = capsule.GetComponent<CapsuleCollider>();
            collider.height = newScale.y * 2;
            collider.radius = 0.5f;
            capsule.SetActive(false);
            GameObjects.Add(capsule);
        }

        public static GameObject GetGameObject(string name) {
            return GameObjects.First(x => x.name == name);
        }

        public static GameObject InstantiateActor(string name, GameObject parent) {
            GameObject obj = UnityEngine.Object.Instantiate(GetGameObject(name), parent.transform);
            obj.name = "Body";
            obj.SetActive(true);
            return obj;
        }

        public static GameObject DisplayFullscreen(string name) {
            return Instantiate(name, Canvas.transform.Find("Player UI").Find("Fullscreen"));
        }

        public static GameObject DisplayWindow(string name) {
            return Instantiate(name, Canvas.transform.Find("Player UI").Find("View Area").Find("Middle Section").Find("Windows Section"));
        }

        internal static GameObject Instantiate(string prefabID, GameObject parent) {
            return Instantiate(prefabID, parent.transform);
        }

        internal static GameObject Instantiate(string prefabID, Transform parent) {
            GameObject prefab = AssetManager.Prefab(prefabID);
            GameObject instance = GameObject.Instantiate(prefab, parent);
            return instance;
        }
    }
}