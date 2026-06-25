using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    //Enemy finds the player and links it own agent
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; 
        agent = GetComponent<NavMeshAgent>();
    }

    //Chase the player
    void Update()
    {
        agent.SetDestination(target.position);
    }
}