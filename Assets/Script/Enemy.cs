using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public Animator animator;
   public int maxHealth = 100;
   private int currentHealth;
   private void Start()
   {
      currentHealth = maxHealth;
   }

   public void TakeDamage(int damage)
   {
      currentHealth -= damage;
      
      animator.SetTrigger("hit");
      
      if (currentHealth <= 0)
      {
         Die();
      }
   }

   private void Die()
   {
      Debug.Log("enemy died");
      animator.SetBool("isDead",true);
      GetComponent<Collider2D>().enabled = false;
      this.enabled = false;
   }
}
