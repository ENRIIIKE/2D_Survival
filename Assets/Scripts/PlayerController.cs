using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [HideInInspector] public Rigidbody2D rb;

    [Header("Movement")]
    public float speed;
    public bool isMoving;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(x * speed, y * speed);


        if (x == 0 && y == 0)
        {
            rb.velocity = Vector2.zero;
        }

        if (x != 0 || y != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}
