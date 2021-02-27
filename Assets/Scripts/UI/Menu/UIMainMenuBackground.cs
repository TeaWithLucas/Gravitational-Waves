using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBackground : MonoBehaviour {
    public float FadeRate;
    
    private float targetAlpha;
    private GameObject Background;
    private Image BackgroundImage;


    // Start is called before the first frame update
    void Start() {
        
        Background = transform.Find("Background").gameObject;
        BackgroundImage = Background.GetComponent<Image>();
        if (Background == null) {
            Debug.LogError("Error: No image on " + name);
        } else {
            targetAlpha = BackgroundImage.color.a;
        }
        MySceneManager.LoadSceneAdditive("LIGOMainBuilding");
        FadeOut();
    }

    // Update is called once per frame
    void Update() {
        Color curColor = BackgroundImage.color;
        float alphaDiff = Mathf.Abs(curColor.a - targetAlpha);
        if (alphaDiff > 0.0001f) {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.deltaTime);
            BackgroundImage.color = curColor;
        }
    }

    public void FadeOut() {
        targetAlpha = 0.0f;
    }

    public void FadeIn() {
        targetAlpha = 1.0f;
    }
}
