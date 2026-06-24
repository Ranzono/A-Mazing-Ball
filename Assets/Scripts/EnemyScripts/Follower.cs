using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; 
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
