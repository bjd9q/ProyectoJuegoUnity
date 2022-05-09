using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackTarget;
    public float attackRange = 5.2f;
    public LayerMask enemyLayers;
    public int attackDamage = 30;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }   
    
    void Attack()
     {
         animator.SetTrigger("attack");
         
         Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackTarget.position,attackRange,enemyLayers);
         
       foreach(Collider2D enemy in hitEnemies)
       {
           enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
       }
    }

    void OnDrawGizmosSelected() 
    {
        if(attackTarget== null)
        return;
        Gizmos.DrawWireSphere(attackTarget.position,attackRange);
    }
}
