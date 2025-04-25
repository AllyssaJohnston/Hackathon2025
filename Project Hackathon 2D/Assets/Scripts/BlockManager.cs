using UnityEngine;

public class BlockManager : MonoBehaviour
{

    BoxCollider2D bC;
    SpriteRenderer sR;
    Rigidbody2D rB2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bC = gameObject.GetComponent<BoxCollider2D>();
        sR = gameObject.GetComponent<SpriteRenderer>();
        rB2D = gameObject.GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        Debug.Log("player " + (player == null ? "null" : "not null"));
        if (player != null)
        {
            if (player.spriteColor != sR.color)
            {
                Debug.Log("Stay");
                // Wall
                player.reverseMovement();
                rB2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        Debug.Log("player " + (player == null ? "null" : "not null"));
        if (player != null)
        {
            if (player.spriteColor != sR.color)
            {
                Debug.Log("Stay");
                // Wall
                player.reverseMovement();
                rB2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
