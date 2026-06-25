using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    // Get player and declare offset for use.
   public GameObject player;
   private Vector3 offset;
    void Start()
    {
        
    }
    // LateUpdate is used to avoid jittering
    //we stay at an offset so the camera always keeps the player in the same place in frame.

    void LateUpdate()
    {
        transform.position = player.transform.position + offset; 
    }
//This was originally in Start(), but we want the camera to wait to sreach for the player since we have a function to int the player
public void findPlayer(){
    Debug.Log("Camera found Player");
    player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position; 
}

}
