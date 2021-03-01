using System.Collections;
using System.Collections.Generic;


public interface ITask
{
    string GetTitle();
    string GetDescription();
    int GetRewardScore();

    void Complete(bool value = true);
}
