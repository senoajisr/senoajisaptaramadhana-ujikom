using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject FoodObject;

    public CharacterController controller;
    public Animator animator;

    void Start()
    {
        GameManager.Instance.OnGameOver += OnGameOver;
    }
    
    void Update()
    {
        if (GameManager.Instance.GamePause) return;
        Movement();
        Throw();
    }

    void OnGameOver(bool value)
    {
        animator.SetTrigger("GameOver");
    }

    void Throw()
    {
        bool isShootKeyDown = Input.GetButtonDown("Fire1");
        if (!isShootKeyDown) return;
        animator.SetTrigger("Throw");
        Instantiate(FoodObject, transform);
    }

    void Movement()
    {
        float xDirection = Input.GetAxis("Horizontal");
        
        Vector3 movement = Vector3.zero;
        movement.x = xDirection;
        animator.SetFloat("Direction", movement.x);
        
        controller.Move(movement.normalized * speed * Time.deltaTime);
        
        if (movement == Vector3.zero)
        {
            animator.SetBool("IsWalking", false);
            return;
        }
        
        animator.SetBool("IsWalking", true);
    }
}
