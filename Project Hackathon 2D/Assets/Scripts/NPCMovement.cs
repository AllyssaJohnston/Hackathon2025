using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public GameObject target;
    private Vector2 startPos;
    private NavMeshAgent agent;
    public bool isTargeting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = gameObject.transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.destination = startPos;
        isTargeting = false;
    }

    private void Awake()
    {
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTargeting && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Continue"))) {
            TargetGoal();
        }       
    }

    public void Reset()
    {
        isTargeting = false;
        transform.position = startPos;
        agent.destination  = startPos;
    }

    public void TargetGoal(){
        agent.destination = target.transform.position;
        isTargeting = true;
    }
}
 