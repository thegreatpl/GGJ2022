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
[RequireComponent(typeof(SpriteAnimator))]
[RequireComponent(typeof(Attributes))]
public class Movement : MonoBehaviour
{

    public Attributes Attributes;


    public SpriteAnimator SpriteAnimator; 

    public float WalkingSpeed { get { return Attributes.Speed; } }

    public Direction MovementDirection; 

    // Start is called before the first frame update
    void Start()
    {
        Attributes = GetComponent<Attributes>();
        MovementDirection = Direction.None; 
        SpriteAnimator = GetComponent<SpriteAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (MovementDirection)
        {
            case Direction.None:
                //insert idling animation when animation class done. 
                SpriteAnimator.SetAnimation("idle"); 
                break;
            case Direction.Up:
                transform.position += new Vector3(0, WalkingSpeed) * Time.deltaTime;
                SpriteAnimator.SetAnimation("walkup"); 
                break;
            case Direction.Down:
                transform.position += new Vector3(0, -WalkingSpeed) * Time.deltaTime;
                SpriteAnimator.SetAnimation("walkdown");
                break;
            case Direction.Left:
                transform.position += new Vector3(-WalkingSpeed, 0) * Time.deltaTime;
                SpriteAnimator.SetAnimation("walkleft");
                break;
            case Direction.Right:
                transform.position += new Vector3(WalkingSpeed, 0) * Time.deltaTime;
                SpriteAnimator.SetAnimation("walkright");
                break;
        }
    }
}