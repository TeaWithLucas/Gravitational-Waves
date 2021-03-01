using Game.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum InteractionMethod
{
    Trigger,
    Mouse,
    Key
}

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(NetworkProximityFinder))]
public class InteractionListener : MonoBehaviour, IInteractible { 

    [Tooltip("Toggle whether this Game Object can be interacted with.")]
    public bool IsInteractionAllowed = true;

    [Tooltip("Whether the interaction can be triggered by entering the sphere trigger.")]
    public bool CanTriggerByProximity = false;

    public float triggerRadius = 5f;

    [Tooltip("Whether the interaction can be triggered by mouse click.")]
    public bool CanTriggerByMouse = true;

    [Tooltip("Whether the interaction can be triggered by key press.")]
    public bool CanTriggerByKeys = true;

    [Tooltip("The keys by which the interaction can be triggered.")]
    public List<KeyCode> TriggerKeys = new List<KeyCode> { KeyCode.F };

    public UnityEvent OnInteraction { get; set; }

    private SphereCollider sphereCollider;

    private NetworkProximityFinder networkProximityChecker;

    public void OnEnable() {
        OnInteraction = new UnityEvent();
    }

    public void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = triggerRadius;
        networkProximityChecker = transform.GetComponent<NetworkProximityFinder>();
    }

    public void Interact() {
        OnInteraction?.Invoke();
    }

    public void Update() {

        if (IsInteractableBy(InteractionMethod.Key))
        {
            float distance = networkProximityChecker.DistanceToLocalConn();
            if (distance >= 0 && distance <= triggerRadius)
            {
                foreach (var keyCode in GetTriggerKeys())
                {
                    if (Input.GetKeyDown(keyCode)) {
                        Debug.LogFormat("Key {0} triggered", keyCode);
                        Interact();
                        break;
                    }
                }
            }
        }
    }

    // TODO: Currently clicks on the sphere collider also trigger the interaction. 
    // Change this so it only registers on the specified collider.
    public void OnMouseDown()
    {
        if (IsInteractableBy(InteractionMethod.Mouse))
        {
            float distance = networkProximityChecker.DistanceToLocalConn();
            if (distance >= 0 && distance <= triggerRadius)
            {
                Interact();
            }
        }
    }

    /// <summary>
    /// Returns the list of the keys by which the interaction can be triggered with.
    /// </summary>
    /// <returns>The list of keys.</returns>
    public List<KeyCode> GetTriggerKeys()
    {
        return TriggerKeys;
    }

    /// <summary>
    /// Determines whether the object is interactable by the specified method.
    /// </summary>
    /// <param name="interactionMethod">The specified interaction method.</param>
    /// <returns>True - if the object can be interacted with by the specified method | False - otherwise.</returns>
    public bool IsInteractableBy(InteractionMethod interactionMethod) {

        return interactionMethod switch
        {
            InteractionMethod.Trigger => CanTriggerByProximity,
            InteractionMethod.Mouse => CanTriggerByMouse,
            InteractionMethod.Key => CanTriggerByKeys,
            _ => false,
        };
    }

    /// <summary>
    /// When another object with a collider enters the trigger.
    /// </summary>
    /// <param name="other">The other object's collider compontent.</param>
    private void OnTriggerEnter(Collider other) {
        if (IsInteractableBy(InteractionMethod.Trigger) && other.gameObject.CompareTag("Player")) {
            Interact();
        }
    }
}
