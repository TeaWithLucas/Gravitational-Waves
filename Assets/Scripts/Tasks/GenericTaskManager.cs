using Game.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GenericTaskManager : MonoBehaviour, ITaskPrefab
{
    [SerializeField]
    protected Text _inputCode;

    [SerializeField]
    protected float resetTimeInSeconds = 0.5f;

    private UIUtils UIUtils;

    public TaskWindow Parent { get; set; }

    public GenericTask CurrentGenericTask { get; set; }


    public Button CompleteBtn => throw new System.NotImplementedException();

    public void SetTask(GenericTask currentTask)
    {
        CurrentGenericTask = currentTask;
    }
    public bool CheckGenericTaskAnswer() 
    {
        if (_inputCode.text == CurrentGenericTask.CorrectAnswer)
        {
            _inputCode.text = "Correct";
            return true;
        }
        
        _inputCode.text = "Failed";
        StartCoroutine(UIUtils.ResetCode(_inputCode,  resetTimeInSeconds));
        return false;
        
    }

    public bool IsReady()
    {
        throw new System.NotImplementedException();
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
