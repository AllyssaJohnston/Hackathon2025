using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; 
    public bool canMoveDiagonally = true; 

    private Rigidbody2D rb; 
    private Vector2 movement; 
    private bool isMovingHorizontally = true;
    public Color spriteColor;
    [SerializeField] SpriteRenderer sR;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        sR = gameObject.GetComponent<SpriteRenderer>();
        spriteColor = sR.color;
    }

    void Update()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        // Check for WASD input
        if (Input.GetKey(KeyCode.D))
            horizontalInput = 1f;
        else if (Input.GetKey(KeyCode.A))
            horizontalInput = -1f;

        if (Input.GetKey(KeyCode.W))
            verticalInput = 1f;
        else if (Input.GetKey(KeyCode.S))
            verticalInput = -1f;

        if (canMoveDiagonally)
        {
            movement = new Vector2(horizontalInput, verticalInput);
        }
        else
        {
            if (horizontalInput != 0)
            {
                isMovingHorizontally = true;
            }
            else if (verticalInput != 0)
            {
                isMovingHorizontally = false;
            }

            if (isMovingHorizontally)
            {
                movement = new Vector2(horizontalInput, 0);
            }
            else
            {
                movement = new Vector2(0, verticalInput);
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }


}
