using UnityEngine;
using System.Collections;

public class FlyCameraHelper : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    int viewMode = 1;

    public GameObject sunBlocker;
    
    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        //transform.position = startMarker.position;

        FlyTheCamera();

    }

    // Follows the target position like with a spring
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V)) viewMode *= -1;
        if (Input.GetMouseButtonDown(2)) viewMode *= -1;
        //if (Input.GetKeyDown(KeyCode.V) && viewMode == 1)
        if (Input.GetMouseButtonDown(2) && viewMode == 1)
        {
            FlyTheCameraBack();
            //viewMode = 0;
        }
        //else if (viewMode == -1 && Input.GetKeyDown(KeyCode.V))
        else if (viewMode == -1 && Input.GetMouseButtonDown(2))
        {
            FlyTheCamera();
            //viewMode = 0;
        }
    }

    void LateUpdate()
    {
    }

    private void FlyTheCamera()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    }

    private void FlyTheCameraBack()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed * Time.deltaTime;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        //transform.position = Vector3.Lerp(endMarker.position, startMarker.position, fracJourney);
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    }
}