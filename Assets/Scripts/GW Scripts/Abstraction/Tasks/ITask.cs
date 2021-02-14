using System.Collections;
using System.Collections.Generic;

public interface ITask
{
    bool IsTaskCompleted();
    bool IsTaskInProgress();
    void CompleteTask();


    string GetTaskTitle();
    string GetTaskDescription();

    int GetRewardTaskScore();


}
