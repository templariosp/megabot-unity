using UnityEngine;

public class Megabot : MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 12f;
    public float collisionRadius = 0.25f;
    public Transform foot;
    public LayerMask layerGround;

    private bool jump = false;
    private bool onFloor = false;
    private Vector2 direction = Vector2.zero;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && onFloor)
        {
            jump = true;
        }

        GroundCheck();
    }

    void FixedUpdate()
    {
        Move(Input.GetAxisRaw("Horizontal"));

        if (jump)
        {
            jump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void Move(float move)
    {
        if(move > 0)
            direction = Vector2.right;
        
        if(move < 0)
            direction = Vector2.left;

        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        if(move == 0)
            rb.velocity = new Vector2(0, rb.velocity.y);

        transform.right = direction;
    }

    void GroundCheck()
    {
        onFloor = Physics2D.OverlapCircle(foot.position, collisionRadius, layerGround);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)foot.position, collisionRadius);
    }
}
