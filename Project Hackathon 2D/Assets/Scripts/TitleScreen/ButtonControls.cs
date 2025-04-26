using System.Collections;
using UnityEngine;

public class ButtonControls : MonoBehaviour
{
    SpriteRenderer sR;
    private float alphaChange = .1f;
    private float waitTime = .1f;

    private void Start()
    {
        sR = this.GetComponent<SpriteRenderer>();
        sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, 0);
    }
    public void changeScene()
    {
        StartCoroutine(sceneTransition(true));
    }
    public void quiteGame()
    {
        StartCoroutine(sceneTransition(false));
    }

    IEnumerator sceneTransition(bool change)
    {
        for (int i = 0; i < 10; i++)
        {
            sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, sR.color.a + alphaChange);
            yield return new WaitForSeconds(waitTime);
        }
        yield return new WaitForSeconds(0.3f);
        if (change)
        {
            MainManager.NextStage();
        }
        else
        {
            Application.Quit();
        }
    }
}
