using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractiveGameObject))]
public class TaskInteractionConfiguration : MonoBehaviour
{

    public bool IsInteractionAllowed = true;
    public bool CanTriggerByKeys = true;
    public bool CanTriggerByMouse = true;
    public bool CanTriggerByProximity = false;
    public float TriggerRadius = 3f;
    public List<KeyCode> TriggerKeys = new List<KeyCode> { KeyCode.E };


    private InteractiveGameObject interactiveComponent;
   
    void Start()
    {

        interactiveComponent = GetComponent<InteractiveGameObject>();
        interactiveComponent.triggerRadius = TriggerRadius;

        interactiveComponent.triggerKeys = TriggerKeys;

        interactiveComponent.IsInteractionAllowed = IsInteractionAllowed;
        interactiveComponent.CanTriggerByKeys = CanTriggerByKeys;
        interactiveComponent.CanTriggerByMouse = CanTriggerByMouse;
        interactiveComponent.CanTriggerByProximity = CanTriggerByProximity;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
