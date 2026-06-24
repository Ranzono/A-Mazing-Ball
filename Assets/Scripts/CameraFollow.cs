using UnityEngine;
public class CameraFollow : MonoBehaviour
{
   public GameObject player;
   private Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; 
    }
public void findPlayer(){
    Debug.Log("Got it");
    player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position; 
}

}
