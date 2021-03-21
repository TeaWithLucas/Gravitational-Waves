using Game.Tasks;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public static class GenericTaskReader
{
    public async static Task<GenericTask[]> ReadTasksFromDiskAsync()
    {
        using StreamReader file = File.OpenText("./tasks.json");

        var jsonString = await file.ReadToEndAsync();

        var tasks = JsonConvert.DeserializeObject<GenericTask[]>(jsonString);

        return tasks;  
    }
}
