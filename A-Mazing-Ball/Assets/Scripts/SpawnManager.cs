using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  // The game object refs tell it what to SPAWN.
  //Must manully set flagid for each flag
   public GameObject Player;
    public GameObject Flag1;
    public GameObject Enemy1;
     public GameObject Flag2;
    public GameObject Enemy2;
 void Start()
    {
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
                 Instantiate(Enemy1, new Vector3(-27, 1, 0), Quaternion.identity);
                break;
                case "Flag2":
                Debug.Log("MATCH! Spawning Enemy2");
                Instantiate(Enemy2, new Vector3(7.5f, 2, 4), Quaternion.identity);
                break;
        }
        
            
    }
    //This, once finsihed will destroy all players, enemies, and flags in scene.
    //Then will int a new player and all the flags
    public void StartGame()
    {
        ClearBoard();
       Instantiate(Player,new Vector3(0, 0.5f, 0), Quaternion.identity);
       Instantiate(Flag1, new Vector3(-40, 2.25f, 0f), Quaternion.Euler(0, 90, 0));
       Instantiate(Flag2, new Vector3(0f, 2.22f, -9f), Quaternion.Euler(0, 90, 0));
       
    }
//finds and removes all players, eneimes, and flags.
    private void ClearBoard()
    {
        foreach (var obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(obj);
        }
        foreach (var obj in GameObject.FindGameObjectsWithTag("Flag"))
        {
            Destroy(obj);
        }
        foreach (var obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(obj);
        }
    }
}

