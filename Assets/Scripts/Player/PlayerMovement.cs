using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; // rigidbody
    private Vector2 movement; // The movement of the player.
    public float speed = 5; // movement Speed
    public float xRange = 7, yRange = 4f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get component
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // Horizontal input movement
        movement.y = Input.GetAxisRaw("Vertical"); // Vertical input movement

        // max range of movement in view
        if (transform.position.x < -xRange) { transform.position = new Vector2(-xRange, transform.position.y); }
        if (transform.position.y < -yRange) { transform.position = new Vector2(transform.position.x, -yRange); }
        if (transform.position.x > xRange) { transform.position = new Vector2(xRange, transform.position.y); }
        if (transform.position.y > yRange) { transform.position = new Vector2(transform.position.x, yRange); }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime); // movvement force
    }
}