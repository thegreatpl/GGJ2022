using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnDamage(); 

public delegate void OnDeath();

public class Attributes : MonoBehaviour
{
    public int HP;

    public int MaxHP;

    public float Speed;

    public int Attack;

    public float AttackDistance;


    public int AttackSpeed; 


    public OnDamage onDamage;
    public OnDeath onDeath;

    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 0)
        {
            onDeath?.Invoke();

            Destroy(gameObject);
            if (tag == "Player")
                GameManager.instance.GameOver(); 
        }
    }


    public void TakeDamage(int damage)
    {
        HP -= damage;

        onDamage?.Invoke(); 
    }
}
