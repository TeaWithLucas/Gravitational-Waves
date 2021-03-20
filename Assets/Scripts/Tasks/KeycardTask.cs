using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeycardTask : MonoBehaviour, ITaskPrefab
{
    [SerializeField]
    protected Text _inputCode;

    [SerializeField]
    protected Text _cardCode;

    [SerializeField]
    protected int _codeLength = 5;

    [SerializeField]
    protected float _codeResetTimeInSeconds = 0.5f;

    private bool _isResetting = false;
    private bool _ready;


    public Button CompleteBtn => throw new System.NotImplementedException();

    public TaskWindow Parent { get; set; }

    public bool IsReady()
    {
        return _ready;
    }

    private void OnEnable()
    {
        if (!IsReady())
        {
            string code = string.Empty;

            for (int i = 0; i < _codeLength; i++)
            {
                code += Random.Range(1, 10);
            }

            _cardCode.text = code;
            _inputCode.text = string.Empty;
            _ready = true;
        }
    }

    public void ButtonClick(int number)
    {
        if (_isResetting) { return; }

        _inputCode.text += number;

        if (_inputCode.text == _cardCode.text)
        { 
            _inputCode.text = "Correct";

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

    public void CompleteTask()
    {
        throw new System.NotImplementedException();
    }

    public void SetParent(TaskWindow parent)
    {
        Parent = parent;
    }
}
