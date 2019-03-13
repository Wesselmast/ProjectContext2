﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaypointCollection : MonoBehaviour {
    private List<Transform> waypoints = new List<Transform>();

    private void Awake() {
        Transform[] wps = GetComponentsInChildren<Transform>();
        foreach (Transform wp in wps.Where(go => go.gameObject != gameObject).ToArray()) {
            if (wp.GetInstanceID() != GetInstanceID()) {
                waypoints.Add(wp);
            }
        }
    }

    public Transform[] GetWaypoints() { return waypoints.ToArray(); }
}