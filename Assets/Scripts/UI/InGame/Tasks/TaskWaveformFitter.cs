using Game.Managers;
using Game.Tasks;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;
using UnityEngine.UI;
using XCharts;

public class TaskWaveformFitter : MonoBehaviour, ITaskPrefab {

    public Button CompleteBtn { get; private set; }
    public Toggle CheckBox { get; private set; }
    public TaskWindow Parent { get; private set; }
    public LineChart LineChart { get; private set; }

    public WaveData ObvservedWave { get; private set; }
    public WaveData PredictedWave { get; private set; }

    public bool Ready { get; private set; }

    private void OnEnable() {
        if (!Ready) {

            CompleteBtn = transform.Find("Button Area").Find("Complete Task Button").GetComponent<Button>();
            LineChart = transform.Find("Graph").GetComponentInChildren<LineChart>();
            Ready = true;
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnDestroy() {
        CompleteBtn.onClick.RemoveAllListeners();
    }

    public void SetParent(TaskWindow parent) {
        Parent = parent;
        CompleteBtn.onClick.AddListener(CompleteTask);
        StartTask();
    }

    public void StartTask() {
        Debug.Log("Starting Task");

        RectTransform rect = Parent.transform.GetComponent<RectTransform>();
        float left, right, top, bottom;
        left = 100;
        right = -100;
        bottom = 100;
        top = -100;

        rect.offsetMin = new Vector2(left, bottom);
        rect.offsetMax = new Vector2(right, top);


        Parent.Task.Started();

        ObvservedWave = new WaveData(AssetManager.JSON<List<List<float>>>("dataHanford"));
        PredictedWave = new WaveData(AssetManager.JSON<List<List<float>>>("NRsim"));

        addLineToGraph(ObvservedWave, "Data");
        addLineToGraph(PredictedWave, "Predicted");
    }

    public void addLineToGraph(WaveData wave, string name) {
        LineChart.AddSerie(SerieType.Line, name);
        foreach (Vector2 coords in wave.ModData) {
            LineChart.AddData(name, coords.x, coords.y);
        }
        updateMaxMin();
    }

    public void updateMaxMin() {
        LineChart.xAxis0.min = ObvservedWave.MinX;
        LineChart.xAxis0.max = ObvservedWave.MaxX;
        LineChart.yAxis0.min = Mathf.Min(ObvservedWave.MinY, PredictedWave.MinY);
        LineChart.yAxis0.max = Mathf.Max(ObvservedWave.MaxY, PredictedWave.MaxY);
        LineChart.RefreshChart();
    }

    public void CompleteTask() {
        Debug.LogFormat("Complete button clicked for Task {0}", Parent.Task.Title);
        
        if (true) { //condition
            Parent.CompleteTask();
        }
    }
}

public class WaveData {

    public float T0 { get; private set; }
    public float M0 { get; private set; }
    public float D0 { get; private set; }
    public float Mass { get; private set; }
    public float Dist { get; private set; }
    public float Scale { get; private set; }
    public List<Vector2> OrgData { get; private set; }
    public List<Vector2> ModData { get; private set; }

    public List<float> Xs => ModData.Select(x => x.x).ToList();
    public List<float> Ys => ModData.Select(x => x.y).ToList();

    public float MinX => Xs.Min();
    public float MaxX => Xs.Max();
    public float MinY => Ys.Min();
    public float MaxY => Ys.Max();

    public WaveData(List<List<float>> data, float mass= 65, float dist= 420) {
        T0 = 0.423f;
        M0 = mass;
        D0 = dist;
        OrgData = new List<Vector2>();
        OrgData = listToVector(data);
        scale(M0, D0);
    }

    public void shiftt(float t0) {
        foreach (Vector2 coords in OrgData) {
            //this.t[i] += t0;
        }
    }

    public List<Vector2> listToVector(List<List<float>> orig) {
        List<Vector2> list = new List<Vector2>();

        foreach (List<float> coords in orig) {
            if (coords.Count > 1) {
                list.Add(new Vector2(coords[0], coords[1]));
            }
        }
        return list;
    }


    public void scale(float m, float d) {
        ModData = new List<Vector2>();
        Debug.LogFormat("scaling from {0} to {1} and from {2} to {3}", M0, m, D0, d);
        Mass = m;
        Dist = d;
        for (int i = 0; i < OrgData.Count; i++) {
            float xMod = (OrgData[i].x - T0) * M0 / Mass + T0;
            float yMod = OrgData[i].y * (Mass / M0) * (D0 / Dist);
            ModData.Add(new Vector2(xMod, yMod));
        }
    }


}