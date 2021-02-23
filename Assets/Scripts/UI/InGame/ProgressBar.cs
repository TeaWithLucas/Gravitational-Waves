using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    public float FillingSpeed = 0.5f;
    private float targetProgress = 0f;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        IncrementProgressBar(0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
            slider.value += FillingSpeed * Time.deltaTime;
    }

    public void IncrementProgressBar(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
