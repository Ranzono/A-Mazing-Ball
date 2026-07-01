using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;
    private Vector2 MoveInput;
    public float ImpulseValue = 10;  
    public float MoveValue = 10;
    private bool IsMoving = false;
    private SpawnManager spawner;
    void Start()
    {
    PlayerRb = GetComponent<Rigidbody>();
     Debug.Log("PlayerController loaded");
     spawner = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

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
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            spawner.StartGame();
        }
    }
}
