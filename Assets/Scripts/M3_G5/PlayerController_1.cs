using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_1 : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(h, v);

        if (h != 0 || v != 0)
        {
            float length = dir.magnitude;

            if (length > 1)
            {
                dir = dir / length;
            }
        }
        _rb.MovePosition(_rb.position + dir * (speed * Time.deltaTime));
    }
}


