using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManagger : MonoBehaviour
{
    List<NavMeshAgent> agents = new List<NavMeshAgent>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] a = GameObject.FindGameObjectsWithTag("AI");
        foreach (GameObject b in a)
        {
            agents.Add(b.GetComponent<NavMeshAgent>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                foreach(NavMeshAgent a in agents)
                {
                    a.SetDestination(hit.point);
                }
            }
        }
    }
}
