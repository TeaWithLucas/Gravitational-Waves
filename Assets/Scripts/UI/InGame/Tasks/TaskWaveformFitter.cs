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
    public GameObject TotalMassContainer { get; private set; }
    public Slider TotalMassSlider { get; private set; }
    public TextMeshProUGUI TotalMassLabel { get; private set; }
    public GameObject DistanceContainer { get; private set; }
    public Slider DistanceSlider { get; private set; }
    public TextMeshProUGUI DistanceLabel { get; private set; }

    public float TotalMassCorrect = 65;
    public float TotalMassMin = 20;
    public float TotalMassMax = 100;
    public float TotalMassStartMin = 30;
    public float TotalMassStartMax = 90;

    public float DistanceCorrect = 420;
    public float DistanceMin = 100;
    public float DistanceMax = 800;
    public float DistanceStartMin = 200;
    public float DistanceStartMax = 700;

    public float WinConditionPercent = 5;

    private void OnEnable() {
        if (!Ready) {
            TotalMassContainer = transform.Find("Interaction Area").Find("Total Mass").gameObject;
            TotalMassSlider = TotalMassContainer.GetComponentInChildren<Slider>();
            TotalMassLabel = TotalMassContainer.transform.Find("Label").GetComponentInChildren<TextMeshProUGUI>();

            DistanceContainer = transform.Find("Interaction Area").Find("Distance").gameObject;
            DistanceSlider = DistanceContainer.GetComponentInChildren<Slider>();
            DistanceLabel = DistanceContainer.transform.Find("Label").GetComponentInChildren<TextMeshProUGUI>();

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
        TotalMassSlider.onValueChanged.RemoveAllListeners();
        DistanceSlider.onValueChanged.RemoveAllListeners();
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

        float initalTotalMass = UnityEngine.Random.Range(TotalMassStartMin, TotalMassStartMax);
        float initalDistance = UnityEngine.Random.Range(DistanceStartMin, DistanceStartMax);

        initSliders(initalTotalMass, initalDistance);


        Parent.Task.Started();

        ObvservedWave = new WaveData(AssetManager.JSON<List<List<float>>>("dataHanford"));
        PredictedWave = new WaveData(AssetManager.JSON<List<List<float>>>("NRsim"), TotalMassCorrect, DistanceCorrect, initalTotalMass, initalDistance);

        UpdateLineOnGraph(ObvservedWave, "Data");
        UpdateLineOnGraph(PredictedWave, "Predicted");

        TotalMassSlider.onValueChanged.AddListener(SliderChanged);
        DistanceSlider.onValueChanged.AddListener(SliderChanged);

    }

    public void initSliders(float initalTotalMass, float initalDistance) {
        TotalMassSlider.minValue = TotalMassMin;
        TotalMassSlider.maxValue = TotalMassMax;
        TotalMassSlider.value = initalTotalMass;

        DistanceSlider.minValue = DistanceMin;
        DistanceSlider.maxValue = DistanceMax;
        DistanceSlider.value = initalDistance;
    }

    public void UpdateLineOnGraph(WaveData wave, string name) {
        Serie line;
        if(LineChart.series.Contains(name)) {
            line = LineChart.series.GetSerie(name);
            line.ClearData();
        } else {
            line = LineChart.AddSerie(SerieType.Line, name);
            line.clip = true;
        }
        
        
        foreach (Vector2 coords in wave.ModData) {
            line.AddXYData(coords.x, coords.y);
        }
        updateMaxMin();
        //LineChart.RefreshChart();
    }



    public void updateMaxMin() {
        LineChart.xAxis0.min = ObvservedWave.MinX; //(float)Math.Round(ObvservedWave.MinX, 2);
        LineChart.xAxis0.max = ObvservedWave.MaxX; //(float)Math.Round(ObvservedWave.MaxX, 2);
        LineChart.yAxis0.min = ObvservedWave.MinY*2; //(float)Math.Round(ObvservedWave.MinY, 0, MidpointRounding.AwayFromZero);
        LineChart.yAxis0.max = ObvservedWave.MaxY*2; //(float)Math.Round(ObvservedWave.MaxY*2, 0, MidpointRounding.AwayFromZero);
        LineChart.RefreshChart();
    }

    public void RefreshChart() {
        PredictedWave.scale(TotalMassSlider.value, DistanceSlider.value);
        UpdateLineOnGraph(PredictedWave, "Predicted");
    }
    public bool WinCondition() {
        float massRange = TotalMassMax - TotalMassMin;
        float massOffset = massRange * (WinConditionPercent / 100);

        float distanceRange = DistanceMax - DistanceMin;
        float distanceOffset = distanceRange * (WinConditionPercent / 100);

        bool massCorrect = TotalMassSlider.value >= TotalMassCorrect - massOffset && TotalMassSlider.value <= TotalMassCorrect + massOffset;
        bool distanceCorrect = DistanceSlider.value >= DistanceCorrect - distanceOffset && DistanceSlider.value <= DistanceCorrect + distanceOffset;
        Debug.LogFormat("mass win range: +/-{0}, guess: {1}, correct: {2}, distance win range: +/-{3}, guess:{4}, correct: {5}", massOffset, TotalMassSlider.value, massCorrect, DistanceSlider.value, distanceOffset, distanceCorrect);
        return massCorrect && distanceCorrect;
    }

    public void CompleteTask() {
        Debug.LogFormat("Complete button clicked for Task {0}", Parent.Task.Title);
        
        if (WinCondition()) { //condition
            Parent.CompleteTask();
        }
    }

    public void SliderChanged(float change) {
        RefreshChart();
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

    public WaveData(List<List<float>> data, float m0 = 65, float d0 = 420, float mass = 65, float dist = 420) {
        T0 = 0.423f;
        M0 = m0;
        D0 = d0;
        OrgData = new List<Vector2>();
        OrgData = listToVector(data);
        scale(mass, dist);
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
        //Debug.LogFormat("scaling from {0} to {1} and from {2} to {3}", M0, m, D0, d);
        Mass = m;
        Dist = d;
        for (int i = 0; i < OrgData.Count; i++) {
            float xMod = (OrgData[i].x - T0) * Mass / M0 + T0;
            
            //float yMod = (OrgData[i].y - T0) * Mass / M0 + T0;
            float yMod = OrgData[i].y * (Mass / M0) * (D0 / Dist);
            ModData.Add(new Vector2(xMod, yMod));
        }
    }


}