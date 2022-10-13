using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;
    public int jumpforce = 10;
    public int speed;
    public bool isOnGround = true;
    public Transform transform;
    public Vector2 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
        startingPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) == true && isOnGround == true) 
        {
            rigidbody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
            isOnGround = false;
        }
        if(Input.GetKeyDown(KeyCode.A) == true)
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D) == true)
        {
            spriteRenderer.flipX = false;
        }
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit Something" + collision);
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
            Debug.Log("Hit the ground");
        }
        if (collision.gameObject.tag == "Enemy")
        {
            transform.position = startingPos;
        }
    }
}
