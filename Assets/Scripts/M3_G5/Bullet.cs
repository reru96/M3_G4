using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    public int lifetime = 2;
    public int damage = 1;

   
    public Vector2 dir
    {
        get;  
        set;
    }
   
    public float Speed => speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void  FixedUpdate()
    {
        rb.velocity = dir * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Enemy enemy = collision.collider.GetComponent<Enemy>();
            if (enemy.health != 0)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
   

    }
}
