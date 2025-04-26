using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class ControlAnimationBehavior : MonoBehaviour
{
    public Button start;
    public Button quit;
    public GameObject panel;
    public TMP_Text text;
    public GameObject image;
    public GameObject image1;
    public GameObject grampa;
    public GameObject curten;
    public GameObject buttonLayout;
    //public GameObject image1; for animation later

    private bool ready = false; 
    private float alphaChange = .1f;
    private float waitTime = .1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reset();
    }

    void Update() 
    {
        if (Input.GetKey(KeyCode.Space) && ready) {
            curten.GetComponent<ButtonControls>().changeScene();
        }
    }

    //to the control screen
    public void onClick()
    {
        Debug.Log("Im aliiive");
        Appear();
    }

    //to the control screen
    public IEnumerator sceneTransition()
    {
        for (int i = 0; i < 10; i++)
        {
            Color panelColor = panel.GetComponent<Image>().color;
            Color textColor = text.faceColor;
            Color npcColor = image.GetComponent<Image>().color;
            Color npcColor2 = image1.GetComponent<Image>().color;

            panel.GetComponent<Image>().color = new Color(panelColor.r, panelColor.g, panelColor.b, panelColor.a - alphaChange);
            text.faceColor = new Color(textColor.r, textColor.g, textColor.b, textColor.a - alphaChange);
            image.GetComponent<Image>().color = new Color(npcColor.r, npcColor.g, npcColor.b, npcColor.a - alphaChange);
            image1.GetComponent<Image>().color = new Color(npcColor2.r, npcColor2.g, npcColor2.b, npcColor2.a - alphaChange);

            yield return new WaitForSeconds(waitTime);
        }
        yield return new WaitForSeconds(0.3f);
        MainManager.SetReadyToTransition(true);
    }

    public void Appear()
    {
        Color panelColor = panel.GetComponent<Image>().color;
        Color textColor = text.color;
        Color npcColor = image.GetComponent<Image>().color;
        Color npcColor2 = image1.GetComponent<Image>().color;
        Color grampasSkin = grampa.GetComponent<SpriteRenderer>().color;
        Color buttonColors = buttonLayout.GetComponent<SpriteRenderer>().color;

        panel.GetComponent<Image>().color = new Color(panelColor.r, panelColor.g, panelColor.b, 1);
        text.color = new Color(textColor.r, textColor.g, textColor.b, 1);
        image.GetComponent<Image>().color = new Color(npcColor.r, npcColor.g, npcColor.b, 1);
        image1.GetComponent<Image>().color = new Color(npcColor2.r, npcColor2.g, npcColor2.b, 1);
        buttonLayout.GetComponent<SpriteRenderer>().color = new Color(buttonColors.r, buttonColors.g, buttonColors.b, 1);
        grampa.GetComponent<SpriteRenderer>().color = new Color(grampasSkin.r, grampasSkin.g, grampasSkin.b, 0);

        gameObject.GetComponent<Canvas>().sortingOrder = 1;
        ready = true;
        MainManager.SetReadyToTransition(true);
    }

    public void Reset()
    {
        Color panelColor = panel.GetComponent<Image>().color;
        Color textColor = text.faceColor;
        Color npcColor = image.GetComponent<Image>().color;
        Color npcColor2 = image1.GetComponent<Image>().color;

        panel.GetComponent<Image>().color = new Color(panelColor.r, panelColor.g, panelColor.b, 0);
        text.faceColor = new Color(textColor.r, textColor.g, textColor.b, 0);
        image.GetComponent<Image>().color = new Color(npcColor.r, npcColor.g, npcColor.b, 0);
        image1.GetComponent<Image>().color = new Color(npcColor2.r, npcColor2.g, npcColor2.b, 0);
        MainManager.SetReadyToTransition(false);
    }
}
