using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour


{
    //delcaring vairiables used for the timer
    public float StartingTime = 30f;
    public float TargetTime = 0f;


    private TMP_Text countdownText;
    public float CurrentTime { get; private set; }

    // Start is called before the first frame update
    void Start() {
        countdownText = transform.GetComponentInChildren<TMP_Text>();
        CurrentTime = StartingTime;
        
    }

    // Update is called once per frame
    void Update() {


        //(Ignore if timer has stopped).
        if (CurrentTime != TargetTime) {
            //decreases timer minius one sec
            float newtime = CurrentTime - Time.deltaTime;

            //if below or equal to the target time, set to the target time, this will stop the timer.
            CurrentTime = newtime <= TargetTime ? TargetTime : newtime;
            countdownText.text = CurrentTime.ToString("0");
            
        }
    }
}
