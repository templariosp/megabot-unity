using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megabot : MonoBehaviour
{
    public float speed = 7f;

    private Vector2 direction = Vector2.zero;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move(Input.GetAxisRaw("Horizontal"));
    }

    void Move(float move)
    {
        if(move > 0)
            direction = Vector2.right;
        
        if(move < 0)
            direction = Vector2.left;

        rb.velocity = new Vector2(direction.x * speed, direction.y);

        if(move == 0)
            rb.velocity = new Vector2(0, direction.y);

        transform.right = direction;
    }
}
