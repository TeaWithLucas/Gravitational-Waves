using Game.Tasks;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public static class GenericTaskReader
{
    public static List<StandardTask> ReadTasksFromDisk()
    {
        using StreamReader file = File.OpenText("./asd.json");
        JsonSerializer serializer = new JsonSerializer();
        var tasks = (List<StandardTask>)serializer.Deserialize(file, typeof(List<StandardTask>));

        return tasks;  
    }
}
