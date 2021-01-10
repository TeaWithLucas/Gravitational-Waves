using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Managers {
    public static class InputManager {

        public static bool Ready { get; private set; }
        static InputManager() {
            Debug.Log("Loading InputManager");
            Ready = true;
        }

        public static void Load() { }

        public static void OnMouseLeft() {
            //if (TargetManager.Waiting) {
            //    TargetManager.Targeted();
            //}
        }

        public static void OnKeyF10() {
            Debug.Log("Escape key was pressed.");
            CameraManager.Switch();
        }

        public static void OnKeyF1() {
            Debug.Log("Escape key was pressed.");
            MySceneManager.OverlayMenuToggle();
        }

        public static void OnKeyEscape() {
            Debug.Log("Escape key was pressed.");
            //if (TargetManager.Waiting) {
            //    TargetManager.Cancel();
            //} else {
                MySceneManager.OverlayMenuToggle();
            //}
        }

        public static void SetCursor() {
            SetCursor(null, false);
        }

        public static void SetCursor(Texture2D texture) {
            SetCursor(texture, false);
        }

        public static void SetCursor(Texture2D texture, bool center) {
            Vector2 hotspot = center ? new Vector2(texture.width / 2, texture.height / 2) : Vector2.zero;
            Cursor.SetCursor(texture, hotspot, CursorMode.Auto);
        }

        public static Vector3 GetMousePos() {
            return Input.mousePosition;
        }
    }
}