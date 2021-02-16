using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class StandardTask : Task
{
    public StandardTask(string title, string description, int rewardScore) 
        : base(title, description, rewardScore)
    {

    }
}
