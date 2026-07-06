using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    // Get player and declare offset for use.
   public GameObject player;
   private Vector3 offset;
//   private Vector3 camPos;
    void Start()
    {
        
    }
//This was originally in Start(), but we want the camera to wait to sreach for the player since we have a function to int the player
public void findPlayer(GameObject obj){
    transform.position = new Vector3(0, 10, -10);
    // Debug.Log("Findplayer run");
    player = null;
    // Debug.Log(" Player null");
    player = obj;
    // Debug.Log("player assigned");
        offset = transform.position - player.transform.position; 
        // Debug.Log("offset set to " + offset);
}
 // LateUpdate is used to avoid jittering
    //we stay at an offset so the camera always keeps the player in the same place in frame.

    void LateUpdate()
    {
       if (player != null){
     transform.position = player.transform.position + offset;

        // Debug.Log("Following!");
       }
    }

}
