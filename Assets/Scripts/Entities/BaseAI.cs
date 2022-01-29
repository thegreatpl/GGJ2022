using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : BaseEntityController
{
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

        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
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
}
