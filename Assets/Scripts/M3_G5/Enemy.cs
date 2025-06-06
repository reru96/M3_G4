using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;
    private PlayerController_1 playerController;
   
    private void Awake()
    {
        
        playerController = GetComponent<PlayerController_1>();
    }
    void Start()
    {
        
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

   

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        
        if (collision.collider.CompareTag("Player"))
        {

            Destroy(gameObject);

        }
        if (collision.collider.CompareTag("Bullet"))
        {

            Destroy(gameObject);

        }
    }

}