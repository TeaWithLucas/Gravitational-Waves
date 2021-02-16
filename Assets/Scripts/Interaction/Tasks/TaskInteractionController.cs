using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractiveGameObject))]
[ExecuteInEditMode]
public class TaskInteractionController : MonoBehaviour
{
    private InteractiveGameObject interactiveComponent;
    private bool firstSetup = true;

    void Start()
    {
        if (firstSetup)
        {
            interactiveComponent = GetComponent<InteractiveGameObject>();
            interactiveComponent.triggerRadius = 3f;

            if (interactiveComponent.triggerKeys == null)
                interactiveComponent.triggerKeys = new List<KeyCode> { KeyCode.E };

            interactiveComponent.IsInteractionAllowed = true;
            interactiveComponent.CanTriggerByKeys = true;
            interactiveComponent.CanTriggerByMouse = true;
        }
        firstSetup = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
