using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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