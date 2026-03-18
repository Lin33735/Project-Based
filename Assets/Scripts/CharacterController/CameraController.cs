using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Declaring some variables
    public Transform FollowTarget, LookTarget;
    public float FollowSpeed = 10f;

    //Using LateUpdate so the camera can follow the player once all the movements happened on the current frame
    private void LateUpdate()
    {
        Vector3 targetPosition = FollowTarget.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);

        transform.LookAt(LookTarget);
    }
}
