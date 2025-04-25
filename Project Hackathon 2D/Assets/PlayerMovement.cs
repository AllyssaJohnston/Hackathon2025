using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public bool playerNumber;
    float movementSpeedY;
    float movementSpeedX;

    // Movement variables for ease of change
    float movementAmounts = 0.1f;
    float slowDownAmounts = 0.05f;
    List<Collider2D> disabled = new List<Collider2D>();

    //
    Color spriteColor;
    [SerializeField] SpriteRenderer sR;

    private void Start()
    {
        sR = gameObject.GetComponent<SpriteRenderer>();
        spriteColor = sR.color;
    }

    // Update is called once per frame
    void Update()
    {
        // Player 1 Movement
        if (playerNumber)
        {
            if (Input.GetKey(KeyCode.W))
            {
                // Move along the Y axis
                if (movementSpeedY <= 5)
                {
                    movementSpeedY += movementAmounts;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                // Move along the Y axis
                if (movementSpeedY >= -5)
                {
                    movementSpeedY -= movementAmounts;
                }
            }
            else
            {
                if (movementSpeedY > 0)
                {
                    movementSpeedY -= slowDownAmounts;
                }
                else
                {
                    movementSpeedY += slowDownAmounts;
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                // Move along the Y axis
                if (movementSpeedX <= 5)
                {
                    movementSpeedX += movementAmounts;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                // Move along the Y axis
                if (movementSpeedX >= -5)
                {
                    movementSpeedX -= movementAmounts;
                }
            }
            else
            {
                if (movementSpeedX > 0)
                {
                    movementSpeedX -= slowDownAmounts;
                }
                else
                {
                    movementSpeedX += slowDownAmounts;
                }
            }
        }
        // Player 2 Movement
        else
        {

        }

    }

    private void FixedUpdate()
    {
        // Constantly applies a force to the player
        transform.Translate(new Vector2(movementSpeedX, movementSpeedY) * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When the player enters a block, make the block phasable
        if (spriteColor == collision.gameObject.GetComponent<SpriteRenderer>().color)
        {
            Debug.Log("Entered!");
            disabled.Add(collision.collider);
            collision.collider.enabled = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // When the player leaves a block, make the block solid again
        Debug.Log("Exited!");
        foreach (var c in disabled)
        {
            c.enabled = true;
        }
    }
}
