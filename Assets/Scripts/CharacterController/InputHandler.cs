using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    //This is for the inputs on the keyboard, declaring some variables and calling the player controller script

    //Calling the player script
    public PlayerController CharacterController;

    //Declaring the input actions as variable using the new input system 
    private InputAction _moveAction, _lookAction, _jumpAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //In here, we're assigning those inputActions once the game is started. Its grabbing the actions from the inputSystem 
        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction = InputSystem.actions.FindAction("Jump");


        //The jump is pressed just once, so I have to make this line and another function for jump on the playerCC script
        _jumpAction.performed += OnJumpPerformed;


        //This hides the cursor when the game starts, pretty useful line for future games
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Here we're using Vector2 variables to read the player's inputs based on axis function, meaning if they press A or D, they would move left or right same with W and S = up and down
        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        CharacterController.Move(movementVector);

        //This is grabbing the look Vector in the inputSystem 
        Vector2 lookVector = _lookAction.ReadValue<Vector2>();
        CharacterController.Rotate(lookVector);

    }


    //Making the Jump Function
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        CharacterController.Jump();
    }
}
