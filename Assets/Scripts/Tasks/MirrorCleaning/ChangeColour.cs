using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour

{
    public Renderer rend;
    public Button CleanButton;
    public Button FirstContactButton;
    [SerializeField]
    private Color colorToTurnTo = Color.white;

    private void Start()
    {
        FirstContactButton.onClick.AddListener(Cleaning);
        CleanButton.onClick.AddListener(Clean);
        rend = GetComponent<Renderer>();

        rend.material.color = colorToTurnTo;
    }

    public void Cleaning()
    {
    }
    public void Clean()
    {
    }

    



}
