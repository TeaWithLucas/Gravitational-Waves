using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(UIBehaviour))]
public class UIUtils : MonoBehaviour
{

    private UIBehaviour uiBehaviour;
    private bool _visible = true;

    protected void Awake()
    {
        uiBehaviour = GetComponent<UIBehaviour>();
    }

    /// <summary>
    /// Toggles whether a UI component is visible or not.
    /// </summary>
    public void ToggleVisibility()
    {
        _visible = !_visible;

        uiBehaviour.gameObject.SetActive(_visible);
    }

    public void RotateZBy(float degrees, float duration)
    {
        LeanTween.rotate(gameObject, new Vector3(0, 0, gameObject.transform.rotation.eulerAngles.z + degrees), duration);
    }
}
