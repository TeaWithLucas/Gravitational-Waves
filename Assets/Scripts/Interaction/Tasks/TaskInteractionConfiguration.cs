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

    private GameObject TaskUIFramework;

    private void Awake()
    {
        TaskUIFramework = GameObject.FindGameObjectWithTag("TaskUIFramework");

        TaskUIFramework.SetActive(false);
    }
    void Start()
    {

        interactiveComponent = GetComponent<InteractiveGameObject>();
        interactiveComponent.triggerRadius = TriggerRadius;

        interactiveComponent.triggerKeys = TriggerKeys;

        interactiveComponent.IsInteractionAllowed = IsInteractionAllowed;
        interactiveComponent.CanTriggerByKeys = CanTriggerByKeys;
        interactiveComponent.CanTriggerByMouse = CanTriggerByMouse;
        interactiveComponent.CanTriggerByProximity = CanTriggerByProximity;

        interactiveComponent.OnInteraction.AddListener(OnTaskInteraction);
        
    }
    void OnTaskInteraction()
    {

        TaskUIFramework.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
