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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Spawner.FlagGet(flagId);
           Destroy(gameObject); 
        }
    }
    
}