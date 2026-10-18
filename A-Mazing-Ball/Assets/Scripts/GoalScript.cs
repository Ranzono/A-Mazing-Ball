using UnityEngine;

public class GoalScript : MonoBehaviour
{
    private SpawnManager Spawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         Spawner = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Collided");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Collided");
           Spawner.StartGame();
        }
    }
}
