using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeycardTask : MonoBehaviour
{
    protected Text _inputCode;

    protected Text _cardCode;

    protected static int _codeLength = 5;

    protected static float _codeResetTimeInSeconds = 0.5f;

    private bool _isResetting = false;

    private void OnEnable()
    {
        string code = string.Empty;

        for (int i = 0; i < _codeLength; i++)
        {
            code += Random.Range(1, 10);
        }

        _cardCode.text = code;
        _inputCode.text = string.Empty;
    }

    public void ButtonClick(int number)
    {
        if (_isResetting) { return; }

        _inputCode.text += number;

        if (_inputCode.text == _cardCode.text)
        {
            _inputCode.text = "Correct";
            StartCoroutine(ResetCode());
        }
        else if (_inputCode.text.Length > _codeLength)
        {
            _inputCode.text = "Failed";
            StartCoroutine(ResetCode());
        }
    }

    private IEnumerator ResetCode()
    {
        _isResetting = true;

        yield return new WaitForSeconds(_codeResetTimeInSeconds);

        _inputCode.text = string.Empty;
        _isResetting = false;
    }


}
