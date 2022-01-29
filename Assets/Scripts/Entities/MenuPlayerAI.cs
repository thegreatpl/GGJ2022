using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerAI : BaseAI
{

    public Vector3[] Waypoints;

    public int currentWaypoint; 
    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<Movement>();
        Attributes = GetComponent<Attributes>();
    }

    // Update is called once per frame
    void Update()
    {
        DumbMoveToPosition(Waypoints[currentWaypoint]); 
        if (Vector3.Distance(Waypoints[currentWaypoint], transform.position) < 0.1f)
        {
            currentWaypoint++; 
            if (currentWaypoint >= Waypoints.Length)
                currentWaypoint = 0;
        }
    }
}
