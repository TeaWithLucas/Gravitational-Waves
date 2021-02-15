using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractiveGameObject))]
[RequireComponent(typeof(SphereCollider))]
public class TaskInteractionController : MonoBehaviour
{
    public GameObject PlayerObject;

    [Tooltip("Toggle whether this Game Object can be interacted with.")]
    public bool IsInteractible = true;

    private SphereCollider sphereCollider;
    private InteractiveGameObject interactiveComponent;

    // Start is called before the first frame update
    void Start()
    {
        interactiveComponent = GetComponent<InteractiveGameObject>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    { 
    }

    /// <summary>
    /// When another object with a collider enters the trigger.
    /// </summary>
    /// <param name="other">The other object's collider compontent.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (!IsInteractible) return;

        if (other.gameObject.CompareTag("Player"))
        {
            interactiveComponent.Interact();
        }
    }
}
