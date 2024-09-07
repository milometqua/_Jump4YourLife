using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Base : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 director;
    private float limitX = 1.28f;
    private void Start()
    {
        director = Vector3.right;
    }
    void Update()
    {
        Move();
        float x = transform.position.x;
        if (x >= limitX)
            director = Vector3.left;
        else if(x <= limitX*(-1f))
            director = Vector3.right;

    }
    private void Move()
    {
          transform.position += director * speed * Time.deltaTime;
    }
}
