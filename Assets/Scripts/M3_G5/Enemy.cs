using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;
    private PlayerController_1 playerController;
    public AudioSource[] musicClip = new AudioSource[2];
    musicClip[0] = public AudioSource ost;
    musicClip[1] = public AudioSource ost2;
    public AudioSource deadSound;

    public int health = 2;
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

    public int AddHp(int amount)
    {


        health = Mathf.Max(health + amount, 0);
        return health;

    }

    public int TakeDamage(int damage)
    {
        return AddHp(-damage);
    }

    public bool IsDeaD(int hp)
    {
        if (health == 0)
        {
         Destroy(gameObject);
         return true; 
        }
        else
        { return false; }
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
        int index = Random.Range(0, musicClip.Length);
        
        if (collision.collider.CompareTag("Player"))
        {
            
            if (health != 0)
            { musicClip[index].Play();
            }
            if (IsDeaD(health))
            {
                deadSound.Play();
            }

        }
        if (collision.collider.CompareTag("Bullet"))
        {
          
            if (health != 0)
            { musicClip[index].Play(); }

            if (IsDeaD(health))
            {
                deadSound.Play();
            }

        }
    }

}