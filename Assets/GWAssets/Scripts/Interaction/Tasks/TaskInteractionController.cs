using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractiveGameObject))]
public class TaskInteractionController : MonoBehaviour
{
    private InteractiveGameObject interactiveGameObject;

    // Start is called before the first frame update
    void Start()
    {
        interactiveGameObject = GetComponent<InteractiveGameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
