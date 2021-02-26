using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    public float IntitalValue = 0f;
    public float FillingSpeed = 0.5f;
    private float targetProgress = 0f;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = IntitalValue;

    }
    // Start is called before the first frame update
    void Start()
    {
        
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
