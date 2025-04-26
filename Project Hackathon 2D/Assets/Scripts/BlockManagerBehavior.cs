using UnityEngine;

public class BlockManagerBehavior : MonoBehaviour
{
    Vector2 startPos;
    BoxCollider2D bC;
    SpriteRenderer sR;
    Rigidbody2D rB2D;
    public Color spriteColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bC = gameObject.GetComponent<BoxCollider2D>();
        sR = gameObject.GetComponent<SpriteRenderer>();
        rB2D = gameObject.GetComponent<Rigidbody2D>();
        startPos = gameObject.transform.position;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        ResolveCollision(collision);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        ResolveCollision(collision);
    }

    private void ResolveCollision(Collision2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        Debug.Log("player " + (player == null ? "null" : "not null"));
        if (player != null)
        {
            Debug.Log(player.getColor() + " " + spriteColor);
            if (compareColor(player.getColor(), spriteColor))
            {
                rB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                Debug.Log("Stay");
                // Wall
                player.reverseMovement();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rB2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    private bool compareColor(Color c1, Color c2)
    {
        return Mathf.Abs(c1.r - c2.r) <= .5f && Mathf.Abs(c1.g - c2.g) <= .5f && Mathf.Abs(c1.b - c2.b) <= .5f;
    }


    public void Reset()
    {
        rB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.position = startPos;
        rB2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }
}
