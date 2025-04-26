using System.Collections;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    [SerializeField] Canvas transistionPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("start transition");
        StartCoroutine(transistionPanel.GetComponent<CanvasTransistionBehavior>().sceneTransition());
    }

}
