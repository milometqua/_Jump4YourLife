using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jump;
    private float y;
    private Rigidbody2D rb;
    private int jumpForce;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        jump = false;
        jumpForce = 2;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
            jump = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Base"))
        {
            CameraController.instance.Move();
            transform.parent = collision.transform;
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base") && jump)
        {
            transform.SetParent(null);
            collision.collider.isTrigger = true;
            jump = false;
        }
    }
}
