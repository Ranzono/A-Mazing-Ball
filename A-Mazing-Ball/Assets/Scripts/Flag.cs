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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Spawner.FlagGet(flagId);
           Destroy(gameObject); 
        }
    }
    
}