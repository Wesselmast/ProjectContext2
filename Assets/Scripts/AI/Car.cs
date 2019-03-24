using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    [SerializeField] private WaypointCollection patrol;
    [SerializeField] private float speed = 5f;

    private Transform[] waypoints;
    private int index = 0;

    private void Start() {
        waypoints = patrol.GetWaypoints();
        transform.position = waypoints[index].position;
        StartCoroutine(MoveTowardsNextWaypoints());
    }

    private IEnumerator MoveTowardsNextWaypoints() {
        if (index >= waypoints.Length - 1) index = -1;
        index++;
        while (Vector3.Distance(transform.position, waypoints[index].position) > .2f){
            transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, Time.deltaTime * speed);
            transform.LookAt(waypoints[index]);
            yield return null;
        }
        transform.position = waypoints[index].position;
        StartCoroutine(MoveTowardsNextWaypoints());
    }
}
