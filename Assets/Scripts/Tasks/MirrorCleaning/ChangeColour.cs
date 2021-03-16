using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour

{
    public Image mirror;
    public Button CleanButton;
    public Button FirstContactButton;

    private void Start()
    {
    }

    public void Cleaning()
    {
        Debug.LogFormat("Applied First Contact");
        mirror.GetComponent<Image>().color = new Color(255F, 51F, 153F);

    }
    public void Clean()
    {
        Debug.LogFormat("Mirror is now cleaned!");
        mirror.GetComponent<Image>().color = new Color(255F, 255F, 255F);
    }

    



}
