using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandRGB : MonoBehaviour
{
    // Color32 packs to 4 bytes
    public Color32 color = Color.black;

    public void Start()
    {
        color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        this.SetColor(color);
    }


    // Unity clones the material when GetComponent<Renderer>().material is called
    // Cache it here and destroy it in OnDestroy to prevent a memory leak
    Material cachedMaterial;

    void SetColor(Color32 newColor)
    {
        if (cachedMaterial == null) cachedMaterial = GetComponentInChildren<Renderer>().material;
        cachedMaterial.color = newColor;
    }

    void OnDestroy()
    {
        Destroy(cachedMaterial);
    }
}
