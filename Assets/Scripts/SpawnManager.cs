using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   public GameObject Player;
    public GameObject Flag1;
    public GameObject Enemy1;
  private CameraFollow Camera;
    void Start()
    {
        Camera = GameObject.Find("MainCamera").GetComponent<CameraFollow>();
        StartGame();
        Camera.findPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlagGet(string flagId)
    {
        switch (flagId){
        case "Flag1":
                 Debug.Log("MATCH! Spawning Enemy1");
                Instantiate(Enemy1, new Vector3(10, 1, 5), Quaternion.identity);
                break;
        }
            
    }
    void StartGame()
    {
       Instantiate(Player,new Vector3(0, 0.5f, 0), Quaternion.identity);
       Instantiate(Flag1, new Vector3(-3f, 2.8f, -5f), Quaternion.identity);
    }
}
