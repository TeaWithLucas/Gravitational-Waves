using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveGameObject : MonoBehaviour, IInteractible
{
    public UnityEvent OnInteraction;

    public void Interact()
    {
        if (OnInteraction.GetPersistentEventCount() > 0)
        {
            OnInteraction.Invoke();
        }
    }
}
