using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIUtils : MonoBehaviour
{

    private bool _visible = true;

    protected void Awake()
    {
    }

    /// <summary>
    /// Toggles whether a UI component is visible or not.
    /// </summary>
    public void ToggleVisibility()
    {
        _visible = !_visible;

        gameObject.SetActive(_visible);
    }

    public void RotateZBy(float degrees, float duration)
    {
        LeanTween.rotate(gameObject, new Vector3(0, 0, gameObject.transform.rotation.eulerAngles.z + degrees), duration);
    }

    public IEnumerator ResetCode(Text inputCode, float codeResetTimeInSeconds)
    {
        yield return new WaitForSeconds(codeResetTimeInSeconds);

        inputCode.text = string.Empty;
    }
}
