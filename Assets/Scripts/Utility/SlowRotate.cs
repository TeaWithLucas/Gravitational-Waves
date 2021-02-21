using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRotate : MonoBehaviour{

    public float DegreePerSecond;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // Rotate the object around its local y axis at 1 degree per second
        float rotate = Time.deltaTime * DegreePerSecond;
        transform.Rotate(Vector3.up * Time.deltaTime);
    }
}
