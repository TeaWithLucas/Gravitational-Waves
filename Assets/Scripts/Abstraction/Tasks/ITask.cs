using System.Collections;
using System.Collections.Generic;


public interface ITask
{
    string GetTitle();
    string GetDescription();

    void Complete(bool value = true);
}
