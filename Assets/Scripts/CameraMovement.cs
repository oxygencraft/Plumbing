using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float movementSpeed = 0.005f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += movementSpeed;
        transform.position = newPosition;
    }
}
