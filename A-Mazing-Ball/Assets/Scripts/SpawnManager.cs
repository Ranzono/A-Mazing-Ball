using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  // The game object refs tell it what to SPAWN.
  //Must manully set flagid for each flag
   public GameObject Player;
    public GameObject Flag1;
    public GameObject Enemy1;
  private CameraFollow Camera;
    //Finds the camera script, starts the game, and tells the camera it's safe to search for the player.
    //We do thid because the camera would otherwise search and fail before the player is in scene.
    //Camera signal moved within start so the camera can relock after a reset
    void Start()
    {
        Camera = GameObject.Find("MainCamera").GetComponent<CameraFollow>();
        StartGame();
    }

   
    void Update()
    {
        
    }
   // I wanted to keep the spawn scripts in one place
   //Flag id checks which flag and spawns the enemy based on flag
    public void FlagGet(string flagId)
    {
        switch (flagId){
        case "Flag1":
                 Debug.Log("MATCH! Spawning Enemy1");
                 Instantiate(Enemy1, new Vector3(10, 1, 5), Quaternion.identity);
                break;
        }
            
    }
    //This, once finsihed will destroy all players, enemies, and flags in scene.
    //Then will int a new player and all the flags
    void StartGame()
    {
       Instantiate(Player,new Vector3(0, 0.5f, 0), Quaternion.identity);
       Instantiate(Flag1, new Vector3(-3f, 2.25f, -5f), Quaternion.identity);
       Camera.findPlayer();
    }
}

