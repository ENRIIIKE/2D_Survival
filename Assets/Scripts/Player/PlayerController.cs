using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [HideInInspector] public Rigidbody2D rb;

    [SerializeField]
    private SpriteRenderer playerSprite;
    
    [Header("Movement")]
    public float speed;
    public bool isMoving;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(x * speed, y * speed);


        if (x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

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

        //Normalize rb.velocity;
    }
}
