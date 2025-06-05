using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField] float speed;
    private Rigidbody2D _rb;
    private Animator _animator;
    private float x;
    private float y;
    private Vector2 dir;
    private bool _isMoving;
    private bool turning;
    public AudioSource audioSource;
    public AudioClip footSteps;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Animate();
        PlayFootstep();
    }
    public void PlayFootstep()
    {
        audioSource.PlayOneShot(footSteps);
        if (_rb.velocity.x != 0 && _rb.velocity.y !=0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();

        }

 
    }


    private void Movement()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        dir = new Vector2(x, y).normalized;

    }
    private void FixedUpdate()
    {


        _rb.velocity = dir * speed;

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
}

