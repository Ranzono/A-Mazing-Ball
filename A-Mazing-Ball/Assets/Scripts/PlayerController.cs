using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;
    private Vector2 MoveInput;
    public float ImpulseValue = 10;  
    public float MoveValue = 10;
    public float MaxSpeed;
    private bool IsMoving = false;
    private SpawnManager spawner;
    private CameraFollow Camera;
    //Finds the camera script, and tells the camera it's safe to search for the player.
    //We do this because the camera would otherwise search and fail before the player is in scene.
    //Camera signal moved within start so the camera can relock after a reset
    //moved here from spawnmanger beacsue this would finish before the player was loaded
    void Start()
    {
        Camera = GameObject.Find("MainCamera").GetComponent<CameraFollow>();
    PlayerRb = GetComponent<Rigidbody>();
     Debug.Log("PlayerController loaded");
     spawner = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
     Camera.findPlayer(gameObject);

    }

   //This was Hell in a handbasket to fix, USE INVOKE UNITY EVENTS, NOT SEND MESSAGES!!!
   //On starting a input give the player a boost, and apply constant force while held
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started){

        MoveInput = context.ReadValue<Vector2>();
        PlayerRb.AddForce(new Vector3(MoveInput.x, 0, MoveInput.y) * ImpulseValue, ForceMode.Impulse);
     }
     if (context.phase == InputActionPhase.Performed)
        {
             MoveInput = context.ReadValue<Vector2>();
            IsMoving = true;
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            IsMoving = false;
        } 
    }
    
    void Update()
    {
        
    }
   //Since we are using a rolling ball instead of tradtional movement, Fixed update is used to keep physics consistent
    private void FixedUpdate()
    {
        if(IsMoving){
        PlayerRb.AddForce(new Vector3(MoveInput.x, 0, MoveInput.y) * MoveValue, ForceMode.Force);
        }
        if(PlayerRb.linearVelocity.magnitude > MaxSpeed)
        {
            PlayerRb.linearVelocity = PlayerRb.linearVelocity.normalized * MaxSpeed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            spawner.StartGame();
        }
    }
}
