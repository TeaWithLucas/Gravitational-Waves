using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBackground : MonoBehaviour {
    // Start is called before the first frame update
    void Awake() {
        SceneManager.LoadScene("LIGOMainBuilding", LoadSceneMode.Additive);
    }
}
