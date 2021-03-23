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

    private void OnEnable() {
        Transform taskTitleTrans = transform.Find("TaskTitle");
        taskTitle = taskTitleTrans.GetComponentInChildren<TMP_Text>();
        button = transform.GetComponent<Button>();
        image = transform.GetComponent<Image>();
    }

    public void AssignTask(Task task) {
        Task = task;
        taskTitle.text = Task.GetTitle();
    }

    public void ToggleTask() {
        // Task.ToggleCompleted();
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