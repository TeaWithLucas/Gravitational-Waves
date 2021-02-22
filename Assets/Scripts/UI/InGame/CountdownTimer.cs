using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour


{
    //delcaring vairiables used for the timer
    [SerializeField] float currentTime = 0f;
    [SerializeField] float startingTime = 30f;

    private TMP_Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        countdownText = transform.GetComponentInChildren<TMP_Text>();
        currentTime = startingTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        //decreases the timer by one sec
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

    }
}
