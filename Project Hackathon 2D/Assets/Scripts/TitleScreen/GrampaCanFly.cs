using UnityEngine;

public class GrampaCanFly : MonoBehaviour
{
    float grampaMove = 0;
    bool goingUp = true;

    private void FixedUpdate()
    {
        if (goingUp && grampaMove < 0.5f)
        {
            grampaMove += 0.01f;
        }
        else
        {
            goingUp = false;
        }
        if (!goingUp && grampaMove > -0.5f)
        {
            grampaMove -= 0.01f;
        }
        else
        {
            goingUp = true;
        }
        // Moves grampa up and down slowly
        transform.Translate(new Vector2(0, grampaMove) * Time.fixedDeltaTime);
    }
}
