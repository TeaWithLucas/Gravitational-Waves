using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveGameObject : MonoBehaviour, IInteractive
{
    public UnityEvent OnInteraction;

    public void OnInteract()
    {
        if (OnInteraction.GetPersistentEventCount() > 0)
        {
            OnInteraction.Invoke();
        }
    }
}
