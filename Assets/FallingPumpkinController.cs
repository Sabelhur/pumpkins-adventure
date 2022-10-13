using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPumpkinController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public GameObject player;
    BoxCollider2D playerCollider;
    BoxCollider2D pumpkinCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerCollider = player.GetComponent<BoxCollider2D>();
        pumpkinCollider = GetComponent<BoxCollider2D>();
        rigidbody.gravityScale = 0; 
        
    }

    // Update is called once per frame
    void Update()
    {
    // The boundaries of the player and pumpkin
        Bounds playerBounds = playerCollider.bounds;
        Bounds pumpkinBounds = pumpkinCollider.bounds;
        // Translation|| first segment of the if statement- if the left of the pumpkin is less than the right of the player(The players right side is inside the width of the pumpkin)
        // Translation|| second segment of the if statement - if the right of the pumpkin is more than the left of the player(the player has not got out of the width of the pumpkin and is currently inside the width of the pumpkin)
        // Translation|| If the requirements are met the pumpkin will fall down because its gravity scale is changed from none to one making it fall down.
        if(pumpkinBounds.min.x < playerBounds.max.x && playerBounds.min.x < pumpkinBounds.max.x)
        {

            rigidbody.gravityScale = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Collision with the ground");
            Destroy(this.gameObject);
        }
    }
}
