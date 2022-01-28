using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    None,
    Up, 
    Down,
    Left,
    Right
}

[RequireComponent(typeof(Attributes))]
public class Movement : MonoBehaviour
{

    public Attributes Attributes; 

    public float WalkingSpeed { get { return Attributes.Speed; } }

    public Direction MovementDirection; 

    // Start is called before the first frame update
    void Start()
    {
        Attributes = GetComponent<Attributes>();
        MovementDirection = Direction.None; 
    }

    // Update is called once per frame
    void Update()
    {
        switch (MovementDirection)
        {
            case Direction.None:
                //insert idling animation when animation class done. 
                break;
            case Direction.Up:
                transform.position += new Vector3(0, WalkingSpeed) * Time.deltaTime; 
                break;
            case Direction.Down:
                transform.position += new Vector3(0, -WalkingSpeed) * Time.deltaTime;
                break;
            case Direction.Left:
                transform.position += new Vector3(-WalkingSpeed, 0) * Time.deltaTime;
                break;
            case Direction.Right:
                transform.position += new Vector3(WalkingSpeed, 0) * Time.deltaTime;
                break;
        }
    }
}