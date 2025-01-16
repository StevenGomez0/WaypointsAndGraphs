using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;

public class FollowWaypoint : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Time.timeScale = 5;
        Debug.Log("started");
        wps = wpManager.GetComponent<WaypointManager>().waypoints;

        //Invoke("GoToRuin", 2);
    }

    public void GoToHeli()
    {
        agent.SetDestination(wps[0].transform.position);
    }

    public void GoToRuin()
    {
        agent.SetDestination(wps[16].transform.position);
    }

    public void GoToFactory()
    {
        agent.SetDestination(wps[12].transform.position);
    }

    public void GoToSomewhere()
    {
        agent.SetDestination(wps[5].transform.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
