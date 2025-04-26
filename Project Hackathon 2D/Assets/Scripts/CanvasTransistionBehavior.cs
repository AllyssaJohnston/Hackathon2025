using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class CanvasTransistionBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject panel;
    public TMP_Text text;
    public GameObject image;

    private float alphaChange = .1f;
    private float waitTime = .1f;

    private void Start()
    {
        Color panelColor = panel.GetComponent<Image>().color;
        Color textColor = text.faceColor;
        Color npcColor = image.GetComponent<Image>().color;

        panel.GetComponent<Image>().color = new Color(panelColor.r, panelColor.g, panelColor.b, 0);
        text.faceColor = new Color(textColor.r, textColor.g, textColor.b, 0);
        image.GetComponent<Image>().color = new Color(npcColor.r, npcColor.g, npcColor.b, 0);
    }

    public IEnumerator sceneTransition()
    {
        for (int i = 0; i < 10; i++)
        {
            Color panelColor = panel.GetComponent<Image>().color;
            Color textColor = text.faceColor;
            Color npcColor = image.GetComponent<Image>().color;

            panel.GetComponent<Image>().color = new Color(panelColor.r, panelColor.g, panelColor.b, panelColor.a + alphaChange);
            text.faceColor = new Color(textColor.r, textColor.g, textColor.b, textColor.a + alphaChange);
            image.GetComponent<Image>().color = new Color(npcColor.r, npcColor.g, npcColor.b, npcColor.a + alphaChange);

            yield return new WaitForSeconds(waitTime);
        }
        yield return new WaitForSeconds(0.3f);
        MainManager.SetReadyToTransition(true);
    }
}
