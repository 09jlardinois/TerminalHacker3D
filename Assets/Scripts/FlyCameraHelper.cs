using UnityEngine;
using System.Collections;

public class FlyCameraHelper : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    [SerializeField]
    private Transform startMarker;
    [SerializeField]
    private Transform endMarker;

    // Here we set a speed for the linear interpolation. I got this recommended value online.
    [SerializeField][Range(0,1)]
    private readonly float lerpSpeed = 0.125f;

    // A flag that indicates if we are at the starting position (1) or ending position (-1).
    // This determines which one we are attempting to switch to (always the opposite one).
    // Using an int instead of bool or other flag means we can simply multiply by -1 every time
    // the flag needs to change to flip it easily. (neg * neg = positive, pos * neg = negative)
    // (essentially, it's an inverter).
    private int flyToStartOrEndFlag = 1;

    // Here we have a member variable for FlyTheCamera that sets our Lerp target based on
    // whether or not we are at flyToStartOrEndFlag 1 or -1.
    private Vector3 movementTarget;

    void Awake()
    {
        // First we want our camera to start at the start marker (duh) - the Far view.
        transform.position = startMarker.position;

        // Then we must initialize a movement target (just set it to where it's already at
        // so that it doesn't move on game start) or else the game will be confused and it will
        // fall through the floor!!!! Do not remove this!
        movementTarget = transform.position;
    }

    void LateUpdate()
    {
        // We want to fly the camera every frame (even when it's not flying)
        // Since there is no possible way without multithreading (too complex) to wait for
        // the fly to complete after pressing Tab.
        FlyTheCamera();
    }

    private void FlyTheCamera()
    {
        // Here's a flag to determine if Tab was pressed on this frame.
        bool tabWasPressed = Input.GetKeyDown(KeyCode.Tab);

        // If Tab WAS pressed, then flip the flag!
        // BUT! only if the camera is at one of the target positions! This is so it doesn't change path mid-flight.
        if (tabWasPressed)
        {
            if (flyToStartOrEndFlag == 1 && transform.position == startMarker.position)
            {
                movementTarget = endMarker.position;
                flyToStartOrEndFlag *= -1;
            }
            else if (flyToStartOrEndFlag == -1 && transform.position == endMarker.position)
            {
                movementTarget = startMarker.position;
                flyToStartOrEndFlag *= -1;
            }
        }

        // Here is the actual movement, lerping. We tell Lerp our start position, the position we want to go to, and how fast to go.
        Vector3 smoothedMovementTarget = Vector3.Lerp(transform.position, movementTarget, lerpSpeed);
        // This lil guy is the whole shebang. It updates the actual position. 
        transform.position = smoothedMovementTarget;
 
    }
}