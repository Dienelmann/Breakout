using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Physics : MonoBehaviour
{
   
        public float speed = 15f;
    
        private Rigidbody2D rb;
        private float horizontal;
        private float vertical;
        public string AxisNameH;
        public string AxisNameV;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            horizontal = Input.GetAxis(AxisNameH);
            vertical   = Input.GetAxis(AxisNameV);
        }

        private void FixedUpdate()
        {
            Vector2 inputDirection = Vector2.ClampMagnitude(new Vector2(horizontal, vertical), 1f);
        
            // float vectorLength = inputDirection.magnitude;
            //
            // if (vectorLength > 1f)
            // {
            //     rb.velocity = inputDirection.normalized * speed;
            // }
            // else
            // {
            //     rb.velocity = inputDirection * speed;
            // }

            rb.velocity = inputDirection * speed;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("GameBall"))
            {
                float hitDistance = transform.position.y - col.transform.position.y;
                float normalizedHitDistance = hitDistance / col.collider.bounds.extents.y;
                // print(normalizedHitDistance);

                Vector2 newDirection = rb.velocity.normalized;
                newDirection.y += normalizedHitDistance;
                newDirection.Normalize();

                rb.velocity = newDirection * rb.velocity.magnitude;
            }
        }
}


