using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Attributes))]
public class ZombieController : BaseAI
{


    public float DetectionDistance = 5f;


    public Attributes Target;

    int AttackCooldown = 0; 

    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<Movement>();
        Attributes = GetComponent<Attributes>();

        Attributes.onDeath += () =>
        {
            Gibsify(); 
            Destroy(gameObject);
        }; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            Movement.MovementDirection = Direction.None;

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
            && Vector3.Distance(transform.position, Target.transform.position) < Attributes.AttackDistance
            && AttackCooldown < 0)
        {
            Target.TakeDamage(Attributes.Attack);
            AttackCooldown = Attributes.AttackSpeed; 
        }
        AttackCooldown--; 
    }

   
}
