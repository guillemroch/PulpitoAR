using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

[SerializeField] private float jumpForce = 6f;
    
private void OnCollisionEnter2D(Collision2D collision) 
{
    

    if(collision.relativeVelocity.y <= 0f)
    {

        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }
    
    }

}
}
