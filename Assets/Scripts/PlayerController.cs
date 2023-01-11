using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;
    [SerializeField] private float maxSpeed;

    private bool grounded;

    private int pickupCount;

    public int Count
    {
        get => pickupCount;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        pickupCount= 0; 
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector2(1, transform.localScale.y);
            rb.AddForce(new Vector2 (moveHorizontal * speed, 0));
        }
        else if (moveHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector2(1, transform.localScale.y);
            rb.AddForce(new Vector2(moveHorizontal * speed, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space) & grounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) & grounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            grounded = false;
        }

        if (rb.velocity.x > maxSpeed)
        {
            float y = rb.velocity.y;
            rb.velocity = new Vector2(maxSpeed, y);
        }
        if (rb.velocity.x < -maxSpeed)
        {
            float y = rb.velocity.y;
            rb.velocity = new Vector2(-maxSpeed, y);
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pickup"))
        {
            Destroy(collision.gameObject);
            pickupCount++;
        }
    }
}
