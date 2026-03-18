using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declaring some variables this is a script for character controller instead of using a rigidbody
    private CharacterController characterController;

    public float MovementSpeed = 10f, RotationSpeed = 5f, JumpForce = 10f, Gravity = -30f;

    private float _rotationY;
    private float _verticalVelcity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Getting the character controller from the player
        characterController = GetComponent<CharacterController>();
    }

    //This is the Move function the inputHandler is trying to get 
    public void Move(Vector2 movementVector)
    {
        //This calculates the player's movement using Vector3 allowing the player to actually move
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * MovementSpeed * Time.deltaTime;
        characterController.Move(move);

        //Make use of the verticalVelocity to control our player
        _verticalVelcity = _verticalVelcity + Gravity * Time.deltaTime;
        characterController.Move(new Vector3(0, _verticalVelcity, 0) * Time.deltaTime);

    }


    //This is the Rotate functions the InputHandler is going to get to allow the player to control the camera
    public void Rotate(Vector2 rotationVector)
    {
        _rotationY += rotationVector.x * RotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
    }



    //Creating the jump function
    public void Jump()
    {
        if (characterController.isGrounded)
        {
            _verticalVelcity = JumpForce;
        }
    }








    // Update is called once per frame
    void Update()
    {

    }
}
