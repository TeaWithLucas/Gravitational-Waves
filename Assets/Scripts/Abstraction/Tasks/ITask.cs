using System.Collections;
using System.Collections.Generic;


public interface ITask
{
    bool IsCompleted();
    bool IsInProgress();

    string GetTitle();
    string GetDescription();
    int GetRewardScore();


    void CompleteTask();
}
