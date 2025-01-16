using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    Transform goal;
    float speed = 5.0f;
    float accuracy = 2.0f;
    float rotSpeed = 2.0f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    [SerializeField] int currentWP = 0;
    Graph g;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 5;
        Debug.Log("started");
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        g = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];

        //Invoke("GoToRuin", 2);
    }

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[0]);
        currentWP = 0;
    }

    public void GoToRuin()
    {
        Debug.Log("gotoruin invoked");
        g.AStar(currentNode, wps[16]);
        currentWP = 0;
    }

    public void GoToFactory()
    {
        g.AStar(currentNode, wps[12]);
        currentWP = 0;
    }

    public void GoToSomewhere()
    {
        g.AStar(currentNode, wps[5]);
        currentWP = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Debug.Log("lateupdate called");
        if (g.pathList.Count == 0 || currentWP == g.pathList.Count)
        {
            Debug.Log("return called");
            return;
        }

        if (Vector3.Distance(g.pathList[currentWP].getId().transform.position, transform.position) < accuracy)
        {
            Debug.Log("currentNode updated, current wp updated");
            currentNode = g.pathList[currentWP].getId();
            currentWP++;
        }

        if (currentWP < g.pathList.Count)
        {
            Debug.Log("lookat and transform called");
            goal = g.pathList[currentWP].getId().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);

            Vector3 direction = lookAtGoal - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

            transform.Translate(0, 0, speed * Time.deltaTime);
            Debug.Log("translating");
        }
    }
}
