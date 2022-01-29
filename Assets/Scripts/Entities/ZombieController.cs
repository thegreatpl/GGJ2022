using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Attributes))]
public class ZombieController : MonoBehaviour
{
    public Movement movement;
    public Attributes attributes;


    public float DetectionDistance = 5f;


    public Attributes Target;

    int AttackCooldown = 0; 

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        attributes = GetComponent<Attributes>();

        attributes.onDeath += () =>
        {
            Destroy(gameObject);
        }; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            movement.MovementDirection = Direction.None;

            var entities = Physics2D.OverlapCircleAll(transform.position, DetectionDistance);
            Target = entities.FirstOrDefault(x => x.gameObject.tag == "Player")?.GetComponent<Attributes>(); 
        }

        if (Target != null)
        {
            DumbMoveToPosition(Target.transform.position);

            Attack(); 
            if (Vector3.Distance(transform.position, Target.transform.position) > DetectionDistance)
            {
                Target = null;
            }
        }

        
    }


    void Attack()
    {
        if (Target != null 
            && Vector3.Distance(transform.position, Target.transform.position) < attributes.AttackDistance
            && AttackCooldown < 0)
        {
            Target.TakeDamage(attributes.Attack);
            AttackCooldown = attributes.AttackSpeed; 
        }
        AttackCooldown--; 
    }

    void DumbMoveToPosition(Vector3 targetPos)
    {
        var distance = targetPos - transform.position;

        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            if (distance.x < 0)
            {
                movement.MovementDirection = Direction.Left; 
            }
            else
                movement.MovementDirection = Direction.Right;
        }
        else
        {
            if (distance.y < 0)
            {
                movement.MovementDirection = Direction.Down;
            }
            else
                movement.MovementDirection = Direction.Up;
        }
    }
}
