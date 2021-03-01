using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Managers;
using Game.Tasks;
using TMPro;
using System;

public class UITaskRow : MonoBehaviour {
    private TMP_Text taskTitle;
    private Button button;
    private Image image;

    public Task Task { get; set; }

    public static bool Ready { get; private set; }

    private void OnEnable() {
        if (!Ready) {
            Transform taskTitleTrans = transform.Find("TaskTitle");
            taskTitle = taskTitleTrans.GetComponentInChildren<TMP_Text>();
            button = transform.GetComponent<Button>();
            image = transform.GetComponent<Image>();
        }
    }

    private void Start() {  

    }

    public void AssignTask(Task task) {
        Task = task;
        taskTitle.text = Task.GetTitle();
    }

    public void ToggleTask() {
        Task.ToggleCompleted();
        TaskManager.TaskUpdated();
    }

    internal void Update() {
        taskTitle.text = Task.GetTitle();
        SetColor();
    }
    public void SetColor() {
        if (Task.IsCompleted) {
            image.color = new Color(0.5f, 0.5f, 0.5f);
        } else {
            image.color = new Color(0.397f, 0.376f, 0.458f, 0.7f);
        }
    }
    
}