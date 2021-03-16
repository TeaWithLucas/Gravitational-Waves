using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInteractible {
    /// <summary>
    /// This method is called when the current object is interacted with.
    /// (Event method)
    /// </summary>
    void Interact();
}
