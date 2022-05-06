using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Move : MonoBehaviour {
    private  Rigidbody2D _rigidbody2D;
    private float izqOder;
    private bool enSuelo;
    private Animator _animator;
   
    
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

      
    void Update() {
        izqOder = Input.GetAxisRaw("Horizontal");

        if (izqOder < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 0.0f);
        else if (izqOder > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);
        
        
        _animator.SetBool("running", izqOder != 0.0f);
        _animator.SetBool("jump", enSuelo ==false);
        _animator.SetBool("fall", enSuelo != true);
        Debug.DrawRay(transform.position, Vector3.down * 0.45f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.45f)) 
        {
            enSuelo = true;
        }
        else enSuelo = false;
        

        if (Input.GetKeyDown(KeyCode.W) && enSuelo) {
            Salto();
        }
    }

    private void Salto() {
        _rigidbody2D.AddForce(Vector2.up * 490.00f);
    }

    private void FixedUpdate() {
        _rigidbody2D.velocity = new Vector2(izqOder*2.8f, _rigidbody2D.velocity.y);
    }
}
