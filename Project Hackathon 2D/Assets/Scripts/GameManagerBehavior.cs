using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    private GameObject[] players;
    private GameObject[] blocks;
    private GameObject[] npcs;
    private GameObject[] transitions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        blocks = GameObject.FindGameObjectsWithTag("Block");
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        transitions = GameObject.FindGameObjectsWithTag("Transition");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //level reset
            foreach (GameObject player in players)
            {
                player.GetComponent<PlayerMovement>().Reset();
            }
            foreach (GameObject block in blocks)
            {
                block.GetComponent<BlockManagerBehavior>().Reset();
            }
            foreach (GameObject transition in transitions)
            {
                transition.GetComponent<CanvasTransitionBehavior>().Reset();
            }
            foreach (GameObject npc in npcs)
            {
                npc.GetComponent<NPCMovement>().Reset();
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MainManager.AttemptToTransition();
        }
    }
}
