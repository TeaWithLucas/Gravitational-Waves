using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour

{
    public Renderer rend;
    public Button CleanButton;
    public Button FirstContactButton;

    private void Start()
    {
        FirstContactButton.onClick.AddListener(Cleaning);
        CleanButton.onClick.AddListener(Clean);
    }

    public void Cleaning()
    {
        rend = GetComponent<Renderer>();

        rend.material.color = new Color(255F, 51F, 153F);

    }
    public void Clean()
    {
         
        rend = GetComponent<Renderer>();

        rend.material.color = new Color(255F, 255F, 255F);
    }

    



}
