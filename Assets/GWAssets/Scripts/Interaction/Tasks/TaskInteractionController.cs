using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractiveGameObject))]
public class TaskInteractionController : MonoBehaviour
{
    public GameObject PlayerObject;
    private InteractiveGameObject interactiveComponent;

    // Start is called before the first frame update
    void Start()
    {
        interactiveComponent = GetComponent<InteractiveGameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
