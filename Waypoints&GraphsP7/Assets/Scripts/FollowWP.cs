using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    //follow waypoint behavior
    public GameObject[] waypoints;
    int currentWP = 0;

    public float speed = 10.0f;
    public float rotationSpeed = 10.0f;
    public float distanceThreshold = 3;
    public float lookAhead = 10;

    GameObject tracker;

    private void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = transform.position;
        tracker.transform.rotation = transform.rotation;
    }

    void progressTracker()
    {

        if (Vector3.Distance(tracker.transform.position, transform.position) > lookAhead) return;

        if (Vector3.Distance(tracker.transform.position, waypoints[currentWP].transform.position) < distanceThreshold)
        {
            currentWP++;
            if (currentWP >= waypoints.Length) { currentWP = 0; }
        }

        tracker.transform.LookAt(waypoints[currentWP].transform);
        tracker.transform.Translate(0, 0, (speed + 2) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        progressTracker();

        Quaternion lookatWaypoint = Quaternion.LookRotation(tracker.transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookatWaypoint, rotationSpeed * Time.deltaTime);

        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
