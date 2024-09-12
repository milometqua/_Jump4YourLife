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
    void OnEnable()
    {
        Messenger.AddListener(EventKey.SETPARENTNULL, SetParentNull);
    }
    void OnDisable()
    {
        Messenger.RemoveListener(EventKey.SETPARENTNULL, SetParentNull); // Always remember to remove this listener
    }
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
            transform.SetParent(null);
            jump = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            float distance = transform.position.y - CameraController.instance.transform.position.y;
            if (distance < -3f)
                Generator.instance.steps = true;
            Generator.instance.Generate();
            CameraController.instance.Move();
            GameController.instance.ShowScore(distance);
            transform.parent = collision.transform;
        }
        if (collision.gameObject.CompareTag("EndGame"))
        {
            GameController.instance.EndGame();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base") && jump)
        {
            collision.collider.isTrigger = true;
            jump = false;
        }
    }
    public void SetParentNull()
    {
        transform.SetParent(null);
    }
}
