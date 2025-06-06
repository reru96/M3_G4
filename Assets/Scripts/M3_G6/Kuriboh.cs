using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Kuriboh : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;
    private Rigidbody2D _rb;
    private Animator _animator;
    private float x;
    private float y;
    private Vector2 dir;
    private bool _isMoving;
    private bool turning;
    public AudioSource audioSource;
    private int hp = 2;
    public event Action OnDeath;



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }


    public bool IsAlive() => hp > 0;

    public int TakeDamage(int damage) => AddHp(-damage);

    public int AddHp(int amount)
    {
        hp = Mathf.Max(hp + amount, 0);
        if (hp <= 0) Die();
        return hp;
    }

    private void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject, 0.5f); 
    }


    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
        Animate();
    }

    void MoveTowardsPlayer()
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = player.position;
        dir = (targetPos - currentPos).normalized;
        x = dir.x;
        y = dir.y;
        transform.position = Vector2.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
    }

    private void Animate()
    {
        if (dir.magnitude != 0)
        {
            turning = true;

        }
        else
        {
            turning = false;
        }

        if (turning)
        {
            _animator.SetFloat("x", x);
            _animator.SetFloat("y", y);
        }




        if (dir.magnitude > 0.1f)
        {
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
        }

        if (_isMoving)
        {
            _animator.SetFloat("x", x);
            _animator.SetFloat("y", y);
        }

        _animator.SetBool("isMoving", _isMoving);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Bullet bullet = collision.collider.GetComponent<Bullet>();

            if (bullet != null)
            {
                int damage = bullet.Damage;

                TakeDamage(damage);
                Debug.Log("Kuriboh ha preso " + damage + " di danno. Vita rimanente: " + hp);

                audioSource.pitch = UnityEngine.Random.Range(0.1f, 1.1f);
                audioSource.Play();

                if (!IsAlive())
                {
                    OnDeath?.Invoke();
                    Destroy(gameObject, 0.5f);
                }
            }

        }


    }
}


