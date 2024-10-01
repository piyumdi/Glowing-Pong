using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float racketSpeed;
    public float moveIncrement = 10f; // Amount to move each button press

    private Rigidbody2D rb;
    private Vector2 racketDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for keyboard input
        float directionX = Input.GetAxisRaw("Horizontal");
        if (directionX != 0)
        {
            racketDirection = new Vector2(directionX, 0).normalized;
            MoveByKeyboard();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }

    private void MoveByKeyboard()
    {
        rb.velocity = racketDirection * racketSpeed;
    }

    public void MoveLeft()
    {
        rb.MovePosition(rb.position + Vector2.left * moveIncrement);
    }

    public void MoveRight()
    {
        rb.MovePosition(rb.position + Vector2.right * moveIncrement);
    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }
}
