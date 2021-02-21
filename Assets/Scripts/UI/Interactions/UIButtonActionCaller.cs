using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Managers;

[RequireComponent(typeof(Button))]
public class UIButtonActionCaller : MonoBehaviour{

    [SerializeField]
    [Tooltip("Choose what action you want to happen on click.")]
    public ActionManager.ActionsEnum Action;

    public static bool Ready { get; private set; }

    // Start is called before the first frame update
    void Start() {
        if (!Ready) {
            ActionManager.ActionsCallback(Action, gameObject.GetComponent<Button>().onClick);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
