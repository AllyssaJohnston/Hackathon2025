using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public bool playerNumber;
    public Sprite backSideSprite;
    Sprite frontSideSprite;
    float movementSpeedY;
    float movementSpeedX;

    // Movement variables for ease of change
    Vector2 startPos;
    float movementAmounts = 1f;
    float slowDownAmounts = 5f;
    float maxSpeed = 5;
    List<Collider2D> disabled = new List<Collider2D>();

    //
    public Color spriteColor;
    [SerializeField] SpriteRenderer sR;
    [SerializeField] Rigidbody2D rB2D;

    private void Start()
    {
        sR = gameObject.GetComponent<SpriteRenderer>();
        rB2D = gameObject.GetComponent<Rigidbody2D>();
        startPos = gameObject.transform.position;
        frontSideSprite = sR.sprite;
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
                if (movementSpeedY <= maxSpeed)
                {
                    movementSpeedY += movementAmounts;
                }
                if(sR.sprite == frontSideSprite)
                {
                    sR.sprite = backSideSprite;
                }
                    
            }
            else if (Input.GetKey(KeyCode.S))
            {
                // Move along the Y axis
                if (movementSpeedY >= -maxSpeed)
                {
                    movementSpeedY -= movementAmounts;
                }
                if(sR.sprite == backSideSprite)
                {
                    sR.sprite = frontSideSprite;
                }
            }
            else
            {
                movementSpeedY /= slowDownAmounts;
            }
            if (Input.GetKey(KeyCode.D))
            {
                // Move along the Y axis
                if (movementSpeedX <= maxSpeed)
                {
                    movementSpeedX += movementAmounts;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                // Move along the Y axis
                if (movementSpeedX >= -maxSpeed)
                {
                    movementSpeedX -= movementAmounts;
                }
            }
            else
            {
                movementSpeedX /= slowDownAmounts;
            }
        }
        // Player 2 Movement
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // Move along the Y axis
                if (movementSpeedY <= maxSpeed)
                {
                    movementSpeedY += movementAmounts;
                }
                if(sR.sprite == frontSideSprite)
                {
                    sR.sprite = backSideSprite;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                // Move along the Y axis
                if (movementSpeedY >= -maxSpeed)
                {
                    movementSpeedY -= movementAmounts;
                }
                if(sR.sprite == backSideSprite)
                {
                    sR.sprite = frontSideSprite;
                }
            }
            else
            {
                movementSpeedY /= slowDownAmounts;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                // Move along the Y axis
                if (movementSpeedX <= maxSpeed)
                {
                    movementSpeedX += movementAmounts;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                // Move along the Y axis
                if (movementSpeedX >= -maxSpeed)
                {
                    movementSpeedX -= movementAmounts;
                }
            }
            else
            {
                movementSpeedX /= slowDownAmounts;
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
