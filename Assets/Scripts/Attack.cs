using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public LayerMask whatIsEnemy;
    Health _health;
    [SerializeField] GameObject Enemy;
    public float damage = 50f;
    public bool alreadyAttacked = true;
    public float AttackRange;
    public bool enemyInAttackRange;
    public float timeBetweenAttacks;
   
 private void Awake()
       {
           _health = Enemy.GetComponent<Health>();
       }

 void Update()
    {
        enemyInAttackRange = Physics.CheckSphere(transform.position, AttackRange, whatIsEnemy);
        
        //attack range
        if (!alreadyAttacked)
        {
            
            if (Input.GetMouseButtonDown(0) && enemyInAttackRange)
            {
                _health.healthvalue -= damage;
                alreadyAttacked = true;
            }
            Invoke(nameof(ResetAttack) , timeBetweenAttacks );
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        
    }
}
