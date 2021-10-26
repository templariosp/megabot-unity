using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    public float speed = 4f;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (transform.position.x < playerTransform.position.x)
            transform.right = Vector2.left;
        else
            transform.right = Vector2.right;

        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

        if (health <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
