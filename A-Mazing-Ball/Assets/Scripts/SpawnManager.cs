using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class SpawnManager : MonoBehaviour
{
  // The game object refs tell it what to SPAWN.
  //Must manually set flagid for each flag
   public GameObject Player;
    public GameObject Flag1;
    public GameObject Enemy1;
    public GameObject Gate1;
     public GameObject Flag2;
    public GameObject Enemy2;
    public GameObject Gate2;
    public GameObject Flag3;
    public GameObject Enemy3;
    public GameObject Gate3;
    public GameObject Gateset;
    public TextMeshProUGUI ObjectiveText;
    public TextMeshProUGUI CounterText;
public TextMeshProUGUI WarningText;
public int Counter = 0; 
public GameObject GameLight;
private Light GameLightSettings;

 void Start()
    {
           GameLightSettings = GameLight.GetComponent<Light>();
        StartGame();
    }

   
    void Update()
    {
        
    }
   // I wanted to keep the spawn scripts in one place
   //Flag id checks which flag and spawns the enemy based on flag
   //Add flag checks and enemies here 
    public void FlagGet(string flagId)
    {
        switch (flagId){
        case "Flag1":
                 Debug.Log("MATCH! Spawning Enemy1");
                 Instantiate(Enemy1, new Vector3(-27, 1, 0), Quaternion.identity);
                 Gate1.SetActive(false);
                 Counter += 1;
                 Countercheck();
                break;
        case "Flag2":
                Debug.Log("MATCH! Spawning Enemy2");
                Instantiate(Enemy2, new Vector3(7.5f, 2, 4), Quaternion.identity);
                Gate2.SetActive(false);
                Counter += 1;
                Countercheck();
                break;
        case "Flag3":
                Debug.Log("MATCH! Spawning Enemy3");
                Instantiate(Enemy3, new Vector3(-3, 1, 0), Quaternion.identity);
                Gate3.SetActive(false);
                Counter += 1;
                Countercheck();
                break;
        }
        
            
    }
    //This, once finished will destroy all players, enemies, and flags in scene.
    //Then will int a new player and all the flags
    //Add each flag here
    public void StartGame()
    {
        ClearBoard();
       Instantiate(Player,new Vector3(0, 0.5f, 0), Quaternion.identity);
       Instantiate(Flag1, new Vector3(-40, 2.25f, 0f), Quaternion.Euler(0, 90, 0));
       Instantiate(Flag2, new Vector3(20.3f, 2.22f, 1.9f), Quaternion.Euler(0, 90, 0));
        Instantiate(Flag3, new Vector3(-9.2f, 2.22f, -17.55f), Quaternion.Euler(0, 90, 0));
       reactivateGates();
       Counter = 0;
       CounterText.text = "Flags collected " + Counter + "/3";
        WarningText.enabled = false;

GameLightSettings.intensity = 2;
GameLightSettings.color = new Color32 (255, 255, 255, 255);
GameLightSettings.colorTemperature = 5000;
        //Instantiate(Gateset, new Vector3(0, 0.75f, 6.33f), Quaternion.Euler(0, -90, 0));
    }
//finds and removes all players, eneimes, and flags.
    public void ClearBoard()
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
    private void reactivateGates()
    {
        Gate1.SetActive(true);
        Gate2.SetActive(true);
        Gate3.SetActive(true);
    }
    private void Countercheck()
    {
          CounterText.text = "Flags collected " + Counter + "/3";
        if (Counter == 3){
            Debug.Log("can leave");
            Nightmare();
        }
        else
        {
          
            Debug.Log("checked");
            return;
        }
    }
    private void Nightmare()
    {
        Debug.Log("nightemare ran");
        WarningText.enabled = true;
        GameLightSettings.colorTemperature = 1500;
        GameLightSettings.intensity = 8.4f;
        GameLightSettings.color = new Color32 (255, 128, 128, 255);
    }
}

