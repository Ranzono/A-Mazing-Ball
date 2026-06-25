using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;
    private Vector2 MoveInput;
    public float ImpulseValue = 10;  
    public float MoveValue = 10;
    private bool IsMoving = false;
    void Start()
    {
    PlayerRb = GetComponent<Rigidbody>();
     Debug.Log("PlayerController loaded");

    }

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
    private void FixedUpdate()
    {
        // move player
        if(IsMoving){
        PlayerRb.AddForce(new Vector3(MoveInput.x, 0, MoveInput.y) * MoveValue, ForceMode.Force);
        }
    }
}
