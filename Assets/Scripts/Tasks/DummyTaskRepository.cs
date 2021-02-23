using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DummyTaskRepository
{
    private static readonly System.Random random = new System.Random();


    public static List<ITask> Tasks = new List<ITask>
    {
        new StandardTask("Mirror Cleaning", "Clean those mirrors, fool!", 100),
        new StandardTask("Laser pointer", "Point da lazor to the right place!", 50),
        new StandardTask("Easter Crow", "Chirp Chirp", 100),
        new StandardTask("Hello World", "Say Hi!", 200),
    };


    public static ITask GetRandomTask() => Tasks[random.Next(0, Tasks.Count)];
}
