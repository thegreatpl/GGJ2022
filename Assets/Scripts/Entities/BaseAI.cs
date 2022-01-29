using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : BaseEntityController
{

    public Vector3[] Waypoints;

    public int currentWaypoint;


    private Vector3? _wanderTarget; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void DumbMoveToPosition(Vector3 targetPos)
    {
        var distance = targetPos - transform.position;

        if (Vector3.Distance(targetPos, transform.position) < 0.1f)
        {
            Movement.MovementDirection = Direction.None; 
        }
        else if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            if (distance.x < 0)
            {
                Movement.MovementDirection = Direction.Left;
            }
            else
                Movement.MovementDirection = Direction.Right;
        }
        else  
        {
            if (distance.y < 0)
            {
                Movement.MovementDirection = Direction.Down;
            }
            else
                Movement.MovementDirection = Direction.Up;
        }
    }

    protected void DumbWander()
    {
        float range = 5;
        if (_wanderTarget == null)
        {
            if (Random.Range(0, 100) < 5) //25% chance to walking there. 
                _wanderTarget = new Vector3(transform.position.x + Random.Range(-range, range), transform.position.x + Random.Range(-range, range));
            
            return;
        }

        DumbMoveToPosition(_wanderTarget.Value);

        //if (Vector3.Distance(_wanderTarget.Value, transform.position) < 0)
        //    _wanderTarget = null;
       if (Random.Range(0, 1000) < 1)
            _wanderTarget = null; 

    }

    protected void MoveWaypoints()
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
