using Game.UI.InGame.Sections.Items;
using Game.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Game.Managers;

namespace Game.Core {
    public static class Logs {

        public delegate UILog UILogAction();
        public static List<UILog> CombatLogsQueue { get; private set; }
        public static Stack<UILog> CombatLogs { get; private set; }
        public static UnityAction<UILog> OnPushCombatLog { get; set; }

        static Logs() {
            MySceneManager.AddOnGameExitCallback(OnGameExit);
            CombatLogsQueue = new List<UILog>();
            CombatLogs = new Stack<UILog>();
        }

        public static void OnGameExit() {
            Debug.Log("Clearing Logs");
            CombatLogsQueue = new List<UILog>();
            CombatLogs = new Stack<UILog>();
            OnPushCombatLog = null;
        }

        public static UILog NewCombatLog() {
            UILog log = UITemplates.CreateLog(InstanceManager.TempStorage);
            CombatLogsQueue.Add(log);
            return log;
        }

        public static UILog CombatLog(int pos = 0) {
            return CombatLogsQueue.ElementAt(pos);
        }

        public static void CombatLogTextFormat(string format, params object[] args) {
            CombatLogText(string.Format(format, args));
        }

        public static void CombatLogText(string text, int pos = 0) {
            if (pos < 0 || pos >= CombatLogsQueue.Count) {
                Debug.LogWarning("Invalid pos");
                pos = 0;
            }
            //Debug.LogFormat("Logs {0}", CombatLogsQueue.Count());
            CombatLogsQueue.ElementAt(pos).AddText(text);
        }

        public static void CombatLogText(string text, UILog targetLog) {
            UILog log = targetLog;
            log.AddText(text);

        }

        public static void PushCombatLog(int pos = 0) {
            PushCombatLog(CombatLogsQueue.ElementAt(pos));
        }

        public static void PushCombatLog(UILog log) {
            CombatLogsQueue.Remove(log);
            CombatLogs.Push(log);
            OnPushCombatLog?.Invoke(log);
        }
    }
}