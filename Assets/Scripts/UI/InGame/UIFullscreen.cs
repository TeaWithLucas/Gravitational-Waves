using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIFullscreen : MonoBehaviour {

    public Image background { get; private set; }
    private void OnEnable() {
        background = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(!background.enabled && transform.childCount > 0) {
            background.enabled = true;
        } else if (background.enabled && transform.childCount <= 0) {
            background.enabled = false;
        }
    }
}
