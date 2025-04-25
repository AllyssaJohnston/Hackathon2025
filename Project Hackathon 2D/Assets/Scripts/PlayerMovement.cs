using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public bool playerNumber;
    float movementSpeedY;
    float movementSpeedX;

    // Movement variables for ease of change
    Vector2 startPos;
    float movementAmounts = 0.1f;
    float slowDownAmounts = 0.05f;
    List<Collider2D> disabled = new List<Collider2D>();

    //
    Color spriteColor;
    [SerializeField] SpriteRenderer sR;
    [SerializeField] Rigidbody2D rB2D;

    private void Start()
    {
        sR = gameObject.GetComponent<SpriteRenderer>();
        rB2D = gameObject.GetComponent<Rigidbody2D>();
        spriteColor = sR.color;
        startPos = gameObject.transform.position;
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
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // Move along the Y axis
                if (movementSpeedY <= 5)
                {
                    movementSpeedY += movementAmounts;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
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
            if (Input.GetKey(KeyCode.RightArrow))
            {
                // Move along the Y axis
                if (movementSpeedX <= 5)
                {
                    movementSpeedX += movementAmounts;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
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

    }

    private void FixedUpdate()
    {
        // Constantly applies a force to the player
        transform.Translate(new Vector2(movementSpeedX, movementSpeedY) * Time.fixedDeltaTime);
    }

    public Vector2 getDirections()
    {
        return new Vector2(movementSpeedX, movementSpeedY);
    }

    public Color getColor()
    {
        return spriteColor;
    }

    public void reverseMovement()
    {
        movementSpeedX = 0;
        movementSpeedY = 0;
    }

    public void Reset()
    {
        transform.position = startPos;
    }
}
