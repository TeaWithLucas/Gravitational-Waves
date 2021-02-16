using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Managers;
using System.Linq;

[RequireComponent(typeof(Button))]
public class UIActionCaller : MonoBehaviour{

    [SerializeField]
    public string Scene;
    public static bool Ready { get; private set; }

    // Start is called before the first frame update
    void Start() {
        if (ActionManager.ActionListeners.Keys.Any(x => Scene.ToLower().Contains(x.ToLower()))){
            gameObject.GetComponent<Button>().onClick.AddListener(ActionManager.ActionListeners.First(x => Scene.ToLower().Contains(x.Key.ToLower())).Value);
            Ready = true;
        } else {
            Debug.LogWarningFormat("No Action found for button: {0}", Scene);
            Ready = false;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
