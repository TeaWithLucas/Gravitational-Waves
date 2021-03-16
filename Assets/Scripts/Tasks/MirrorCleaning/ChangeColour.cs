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
        mirror = transform.Find("Mirror").GetComponent<Image>();
        CleanButton = transform.Find("CleanButton").GetComponent<Button>();
        FirstContactButton = transform.Find("FirstContactButton").GetComponent<Button>();
    }

    public void Cleaning()
    {
        Debug.LogFormat("Applied First Contact");
        mirror.color = new Color(255F, 51F, 153F);

    }
    public void Clean()
    {
        Debug.LogFormat("Mirror is now cleaned!");
        mirror.color = new Color(255F, 255F, 255F);
    }

    



}
