using Game.Tasks;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public static class GenericTaskReader
{
    public async static Task<StandardTask[]> ReadTasksFromDiskAsync()
    {
        using StreamReader file = File.OpenText("./asd.json");

        var jsonString = await file.ReadToEndAsync();

        var tasks = JsonConvert.DeserializeObject<StandardTask[]>(jsonString);

        return tasks;  
    }
}
