using UnityEngine;

public class Flag : MonoBehaviour
{
   private SpawnManager Spawner;
    [SerializeField] private string flagId;
    void Start()
    {
        Spawner = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        
    }
    //When the player collects the flag, it passes it's id (that is set in editor)
    //And destroys itself
    //If it isn't obvious Randal, make sure box collider is set to "Trigger"
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Collided");
           Spawner.FlagGet(flagId);
           Destroy(gameObject); 
        }
    }
    
}