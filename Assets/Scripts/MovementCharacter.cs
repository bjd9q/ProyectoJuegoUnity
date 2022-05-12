using System;
using UnityEngine;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class MovementCharacter : MonoBehaviour {
  private Rigidbody2D rigidbody2D;
  [SerializeField] private float velocidadPersonaje;
  private Animator animator;
  private SpriteRenderer spritePersonaje;
  float fuerzaSalto = 6f;
  int jumpsCount;
  int limitJumps = 2;


private void Awake(){
  animator = GetComponentInChildren<Animator>();
    rigidbody2D = GetComponent<Rigidbody2D>();
    spritePersonaje = GetComponentInChildren<SpriteRenderer>();
    jumpsCount = 0;
}

private void FixedUpdate(){
    float velocidadinput = Input.GetAxisRaw("Horizontal");
    rigidbody2D.velocity = new Vector2(velocidadinput * velocidadPersonaje, rigidbody2D.velocity.y);
    animator.SetFloat("isRunning", Mathf.Abs (velocidadinput));

    if(velocidadinput < 0){
      spritePersonaje.flipX = true;
    }else if(velocidadinput > 0){
      spritePersonaje.flipX = false;
    }

    if(Input.GetKeyDown(KeyCode.UpArrow)){
      if(jumpsCount<limitJumps){
        animator.SetTrigger("Jump");
        Debug.Log ("salto");
      rigidbody2D.AddForce(new Vector2(0f,fuerzaSalto),ForceMode2D.Impulse);
      jumpsCount++;
      
      
    }
      
  }

    
}

void OnCollisionEnter2D(Collision2D obj){
      if (obj.collider.tag=="Suelo"){
        jumpsCount = 0;
      }
    }
}
