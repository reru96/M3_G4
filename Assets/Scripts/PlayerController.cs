using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        private Rigidbody2D rb;
        public float speed;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
        }

        void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector2 inputDir = new Vector2(h, v).normalized;
            rb.velocity = inputDir * speed;
        }
}
